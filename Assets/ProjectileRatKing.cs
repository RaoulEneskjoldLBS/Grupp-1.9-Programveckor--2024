using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;

    // Method to set the damage of the projectile
    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile collides with an object that has a health component
        if (collision.CompareTag("Player"))
        {
            // Assuming the PlayerHealth script has a TakeDamage method
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);

            // Destroy the projectile on collision
            Destroy(gameObject);
        }
    }
}
