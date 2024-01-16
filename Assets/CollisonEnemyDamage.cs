using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamagePlayer : MonoBehaviour
{
    

    void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(33);

                
            }
        }
    }
}
