using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sakerattkasta : MonoBehaviour
{
    public Throw Ammo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Ammo.AmmoAmount += 1;

            Destroy(gameObject);
        }

    }
}
