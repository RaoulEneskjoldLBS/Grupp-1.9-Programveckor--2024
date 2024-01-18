using UnityEngine;

public class RatKing : MonoBehaviour
{
    public float slamRadius = 5f;
    public float slamDamage = 10f;
    public float slamKnockbackForce = 500f;
    public float slamCooldown = 3f;

    public GameObject projectilePrefab;
    public float projectileSpeed = 8f;
    public float projectileDamage = 5f;
    public float projectileCooldown = 2f;

    private Transform player;
    private bool canSlam = true;
    private bool canShoot = true;
    private float lastShootTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Perform area of effect slam attack with cooldown
        if (canSlam && Vector2.Distance(transform.position, player.position) <= slamRadius)
        {
            PerformSlamAttack();
            StartCoroutine(ResetSlamCooldown());
        }

        // Shoot projectiles with a cooldown
        if (canShoot && Time.time - lastShootTime >= projectileCooldown)
        {
            ShootProjectile();
            lastShootTime = Time.time; // Update the last shoot time
        }
    }

    private void PerformSlamAttack()
    {
        // Add knockback force to the player
        Vector2 knockbackDirection = (player.position - transform.position).normalized;
        player.GetComponent<Rigidbody2D>().AddForce(knockbackDirection * slamKnockbackForce);

        // Deal damage to the player
        player.GetComponent<PlayerHealth>().TakeDamage(slamDamage);
    }

    private void ShootProjectile()
    {
        // Create a projectile and shoot it towards the player
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 shootDirection = (player.position - transform.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = shootDirection * projectileSpeed;
        projectile.GetComponent<Projectile>().SetDamage(projectileDamage);
    }

    private System.Collections.IEnumerator ResetSlamCooldown()
    {
        canSlam = false;
        yield return new WaitForSeconds(slamCooldown);
        canSlam = true;
    }
}

