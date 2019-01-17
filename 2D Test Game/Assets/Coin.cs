using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pickUp();
        }
    }

    void pickUp()
    {
        EventManager.TriggerEvent("CoinPicked");
        Destroy(gameObject);
    }
}
