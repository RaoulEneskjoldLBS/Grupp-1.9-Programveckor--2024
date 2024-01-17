using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupweapon : MonoBehaviour
{
    public Playerpunch HP;
    public float DMG = 10f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HP.dmg += DMG;

            Destroy(gameObject);
        }

    }
}
