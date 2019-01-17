using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {



    public float speed;
    public float lifetime;
    public float damage;

    private float lifetimeleft;
    private bool isAlive = false;

    // Use this for initialization
    void Start () {
        lifetimeleft = lifetime;
        isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {


        if (isAlive)
        {
            lifetimeleft -= Time.deltaTime;

            if (lifetimeleft <= 0)
            {
                isAlive = false;
                lifetimeleft = lifetime;
                Destroy(gameObject);
            }

        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Monster")
        {
            other.GetComponent<slime>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
