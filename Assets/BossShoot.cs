using UnityEngine;

public class RatKing : MonoBehaviour
{
    
    public GameObject projectilePrefab;
    public float projectileSpeed = 8f;
    public float projectileDamage = 5f;
    public float projectileCooldown = 2f;

    private Transform player;
    private bool canSlam = true;
    private bool canShoot = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
       

        // Shoot projectiles with cooldown
        if (canShoot)
        {
            ShootProjectile();
            StartCoroutine(ResetProjectileCooldown());
        }
    }

    

    private void ShootProjectile()
    {
        // Create a projectile and shoot it towards the player
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 shootDirection = (player.position - transform.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = shootDirection * projectileSpeed;
        projectile.GetComponent<Projectile>().SetDamage(projectileDamage);

        canShoot = false; // Disable shooting until the cooldown is over
    }



    private System.Collections.IEnumerator ResetProjectileCooldown()
    {
        yield return new WaitForSeconds(projectileCooldown);

        // Reset shooting after the cooldown is over
        canShoot = true;
    }
}
