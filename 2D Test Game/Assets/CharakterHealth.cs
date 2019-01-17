using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharakterHealth : MonoBehaviour {

    public float health;
    public Image healthBar;

    private float startHealth;
    private bool isDead = false;



    void OnEnable()
    {
        EventManager.StartListening("HeartPicked", Heal);
    }

    void OnDisable()
    {
        EventManager.StopListening("HeartPicked", Heal);
    }

    void Start () {
        startHealth = health;
	}

    void Heal()
    {
        if(health + 20.0f > startHealth)
        {
            health = startHealth;
        }
        else
        {
            health += 20.0f;
        }
        healthBar.fillAmount = health / startHealth;
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            dead();
        }
    }


    private void dead()
    {
        if (!isDead)
        {
            isDead = true;
            EventManager.TriggerEvent("GameOver");

        }
    }
}
