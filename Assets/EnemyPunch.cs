using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleProjectile : MonoBehaviour
{
    public int damageAmount = 10;
    public float projectileLifetime = 0.5f;

    void Start()
    {
    
        GetComponent<Renderer>().enabled = false;


        Destroy(gameObject, projectileLifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
           
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);

            }

            
            Destroy(gameObject);
        }
    }
}
