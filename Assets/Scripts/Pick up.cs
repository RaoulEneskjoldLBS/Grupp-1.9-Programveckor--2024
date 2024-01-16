using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Wall bosswall;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            bosswall.pickupsCollected += 1; 

            Destroy(gameObject);
        }

    }
}
