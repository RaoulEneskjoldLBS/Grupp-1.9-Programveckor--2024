using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupweapon : MonoBehaviour
{
    public string pickupType = "Weapon";

    public float pickupValue = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPickup(other.gameObject);

            Destroy(gameObject);
        }
    }

    void PlayerPickup(GameObject player)
    {
    
    }
}
