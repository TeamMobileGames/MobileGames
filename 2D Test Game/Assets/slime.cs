using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class slime : MonoBehaviour {

    public DropableItem[] dropableItems;

    public float speed;
    public float minDistance;
    public float health;
    public Image healthBar;
    public float damage = 1.0f;
    public float attackCooldown = 0.5f;

    private float startAttackCooldown;
    private GameObject gameObjectSlime;
    private GameObject targetGameObject;
    private float startHealth;
    private Animator animator;
    private int north;
    private int northeast;
    private int east;
    private int eastsouth;
    private int south;
    private int southwest;
    private int west;
    private int westnorth;
    private string monster;
    private bool isDead = false;

    void Start()
    {
        startAttackCooldown = attackCooldown;
        targetGameObject = GameObject.FindWithTag("Player");
        startHealth = health;

        animator = GetComponent<Animator>();
        monster = "slime";
        north = Animator.StringToHash(monster + "_north");
        east = Animator.StringToHash(monster + "_east");
        south = Animator.StringToHash(monster + "_south");
        west = Animator.StringToHash(monster + "_west");

        gameObjectSlime = this.gameObject;

    }



        void Update () {

        if(attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }

        if (Vector2.Distance(transform.position, targetGameObject.transform.position) > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetGameObject.transform.position, speed * Time.deltaTime);
        }
        else
        {
            attack();
        }


        Vector3 dir = targetGameObject.transform.position - transform.position;
        dir = targetGameObject.transform.InverseTransformDirection(dir);
        float ang = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (ang < 0)
        {
            ang = 360 + ang;
        }
        

        setAllFalse();
        if (ang > 0)
        {
            if (ang <= 45 || ang >= 315)
            {
                animator.SetTrigger(east);
            }
            else if (ang <= 135 && ang >= 45)
            {
                animator.SetTrigger(north);
            }
            else if (ang <= 225 && ang >= 135)
            {
                animator.SetTrigger(west);
            }
            else if (ang <= 315 && ang >= 225)
            {
                animator.SetTrigger(south);
            }
        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            dead();
        }
    }

    void attack()
    {
        if(attackCooldown <= 0)
        {
            targetGameObject.GetComponent<CharakterHealth>().takeDamage(damage);
            attackCooldown = startAttackCooldown;
        }
    }

    private void dead()
    {
        if (!isDead) {
            Drop();
            isDead = true;
            EventManager.TriggerEvent("Spawn");
            Destroy(gameObject);
        }
    }

    private void setAllFalse()
    {
        animator.SetBool(north, false);
        animator.SetBool(east, false);
        animator.SetBool(south, false);
        animator.SetBool(west, false);
        
    }

    private void Drop()
    {
        foreach (DropableItem drop in dropableItems)
        {
            float tmp = Random.Range(0.01f, 1f);
            if (tmp < drop.chance) 
            {
                Debug.Log("droped");
                GameObject  item = Instantiate(drop.gameObject);
                item.transform.position = this.transform.position;
            }
        }
    }
}
