using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveByTouch : MonoBehaviour {

    public Joystick joystickWalk;
    public Joystick joystickShoot;

    public Rigidbody2D bulletPrefab;
    public float shootCoolDown;

    public float runSpeed;
    public Animator animatorCharacter;
    public Animator animatorGun;

    private float timeTillNextShoot;

    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    private string gun;
    private string charakter;
    private int north;
    private int northeast;
    private int east;
    private int eastsouth;
    private int south;
    private int southwest;
    private int west;
    private int westnorth;

    private int north1;
    private int northeast1;
    private int east1;
    private int eastsouth1;
    private int south1;
    private int southwest1;
    private int west1;
    private int westnorth1;

    private Vector3 shootingDirection = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
        timeTillNextShoot = shootCoolDown;

        charakter = "1";
        gun = "flamethrower";
        north = Animator.StringToHash(gun + "_north");
        northeast = Animator.StringToHash(gun + "_northeast");
        east = Animator.StringToHash(gun + "_east");
        eastsouth = Animator.StringToHash(gun + "_eastsouth");
        south = Animator.StringToHash(gun + "_south");
        southwest = Animator.StringToHash(gun + "_southwest");
        west = Animator.StringToHash(gun + "_west");
        westnorth = Animator.StringToHash(gun + "_westnorth");

        north1 = Animator.StringToHash(charakter + "_north");
        northeast1 = Animator.StringToHash(charakter + "_northeast");
        east1 = Animator.StringToHash(charakter + "_east");
        eastsouth1 = Animator.StringToHash(charakter + "_eastsouth");
        south1 = Animator.StringToHash(charakter + "_south");
        southwest1 = Animator.StringToHash(charakter + "_southwest");
        west1 = Animator.StringToHash(charakter + "_west");
        westnorth1 = Animator.StringToHash(charakter + "_westnorth");

    }
	
	// Update is called once per frame
	void Update () {

        timeTillNextShoot -= Time.deltaTime;

       // animatorCharacter.SetFloat("angel", 0);
       // animatorGun.SetFloat("angel", 0);
        if (Input.touchCount > 0)
        {
           
            horizontalMove = joystickWalk.Horizontal * runSpeed;
            verticalMove = joystickWalk.Vertical * runSpeed;

                Vector2 fromVector2 = new Vector2(0, 50);
                Vector2 toVector2 = new Vector2(joystickShoot.Direction.x, joystickShoot.Direction.y);

                float ang = Vector2.Angle(fromVector2, toVector2);
                Vector3 cross = Vector3.Cross(fromVector2, toVector2);

            if (cross.z > 0)
            {
                ang = 360 - ang;
            }


            setAllFalse();
            if (ang > 0)
            {
                if (ang <= 25 || ang >= 335)
                {
                    animatorGun.SetTrigger(north);
                    animatorCharacter.SetTrigger(north1);
                    shootingDirection = new Vector3(0, 1, 0);
                }
                else if (ang <= 65 && ang >= 25)
                {
                    animatorGun.SetTrigger(northeast);
                    animatorCharacter.SetTrigger(northeast1);
                    shootingDirection = new Vector3(1, 0.5f, 0);
                }
                else if (ang <= 115 && ang >= 65)
                {
                    animatorGun.SetTrigger(east);
                    animatorCharacter.SetTrigger(east1);
                    shootingDirection = new Vector3(1, 0, 0);
                }
                else if (ang <= 155 && ang >= 115)
                {
                    animatorGun.SetTrigger(eastsouth);
                    animatorCharacter.SetTrigger(eastsouth1);
                    shootingDirection = new Vector3(1, -1, 0);
                }
                else if (ang <= 205 && ang >= 155)
                {
                    animatorGun.SetTrigger(south);
                    animatorCharacter.SetTrigger(south1);
                    shootingDirection = new Vector3(0, -1, 0);
                }
                else if (ang <= 245 && ang >= 205)
                {
                    animatorGun.SetTrigger(southwest);
                    animatorCharacter.SetTrigger(southwest1);
                    shootingDirection = new Vector3(-1, -1, 0);
                }
                else if (ang <= 295 && ang >= 245)
                {
                    animatorGun.SetTrigger(west);
                    animatorCharacter.SetTrigger(west1);
                    shootingDirection = new Vector3(-1, 0, 0);
                }
                else if (ang <= 335 && ang >= 295)
                {
                    animatorGun.SetTrigger(westnorth);
                    animatorCharacter.SetTrigger(westnorth1);
                    shootingDirection = new Vector3(-1, 0.5f, 0);
                }
                if (timeTillNextShoot <= 0)
                {
                    Fire(joystickShoot.Direction.x, joystickShoot.Direction.y, ang);
                }
            }

            //for (int i = 0; i < Input.touchCount; i++){
            //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            //    Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
            //}

            transform.position += new Vector3(horizontalMove, verticalMove, 0) * Time.deltaTime;

           // Touch touch = Input.GetTouch(0);
           // Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
           // touchPosition.z = 0f;
           // transform.position = touchPosition;
        }

	}
    private void setAllFalse()
    {
        animatorGun.SetBool(north, false);
        animatorGun.SetBool(northeast, false);
        animatorGun.SetBool(east, false);
        animatorGun.SetBool(eastsouth, false);
        animatorGun.SetBool(south, false);
        animatorGun.SetBool(southwest, false);
        animatorGun.SetBool(west, false);
        animatorGun.SetBool(westnorth, false);

        animatorCharacter.SetBool(north1, false);
        animatorCharacter.SetBool(northeast1, false);
        animatorCharacter.SetBool(east1, false);
        animatorCharacter.SetBool(eastsouth1, false);
        animatorCharacter.SetBool(south1, false);
        animatorCharacter.SetBool(southwest1, false);
        animatorCharacter.SetBool(west1, false);
        animatorCharacter.SetBool(westnorth1, false);
    }

    void Fire(float x,float y,float angle)
    {
        EventManager.TriggerEvent("FlamethrowerShoot");
        timeTillNextShoot = shootCoolDown;
        // Create the Bullet from the Bullet Prefab
        Rigidbody2D bulletClone = (Rigidbody2D)Instantiate(
            bulletPrefab,
            transform.position + shootingDirection,
            Quaternion.Euler(0, 0, (angle-90)*-1));

        // Add velocity to the bullet
        //bulletClone.GetComponent<Rigidbody2D>().velocity = bulletClone.transform.forward * 6;
        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(x-0.1f, x+0.1f), Random.Range(y-0.1f, y+0.1f)) *3;

        // Destroy the bullet after 2 seconds
        //Destroy(bulletClone, 2.0f);
    }
}
