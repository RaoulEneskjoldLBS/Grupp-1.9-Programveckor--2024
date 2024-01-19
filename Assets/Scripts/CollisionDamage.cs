using System.Collections;
using UnityEngine;


public class AIDamagePlayer : MonoBehaviour
{
    public int damageAmount = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Damage the player
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);

                // Optionally, you can add logic here for the AI's impact on the player,
                // such as applying force, playing impact animations, etc.
            }
        }
    }
}
