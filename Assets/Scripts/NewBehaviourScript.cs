using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float detectionRange = 10f;    // Adjust the detection range as needed
    public float attackRange = 2f;        // Adjust the attack range as needed
    public string playerTag = "Player";
    public int slamDamage = 10;
    public float knockbackForce = 5f;
    public float knockbackDistance = 2f;  // Adjust the knockback distance as needed
    public float slamCooldown = 20f;      // Cooldown in seconds for slam attack
    public float knockbackCooldown = 5f;  // Cooldown in seconds for knockback

    public bool isSlamAttackReady = true;       // Start with the slam attack ready
    public bool isKnockbackReady = true;        // Start with the knockback ready
    public bool isKnockbackInProgress = false;


    private void Update()
    {
        CheckPlayerInRange();
    }

    private void CheckPlayerInRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            // Check if the player is in detection range
            if (distanceToPlayer < detectionRange)
            {
                // Perform slam attack when slam attack is ready
                if (isSlamAttackReady)
                {
                    PerformSlamAttack(player);
                }

                // Perform knockback when knockback is ready
                if (isKnockbackReady)
                {
                    PerformKnockback(player);
                }
            }
        }
    }

    private void PerformSlamAttack(GameObject player)
    {
        // Apply damage to the player using PlayerHealth
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(slamDamage);
        }

        // Apply knockback force to the player
        Vector2 knockbackDirection = (player.transform.position - transform.position).normalized;
        player.GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        // Debug message
        Debug.Log("Boss performs slam attack!");

        // Reset slam attack readiness and set a timer to reset readiness after the cooldown
        isSlamAttackReady = false;
        Invoke("ResetSlamAttackReadiness", slamCooldown);
    }



    

    

    private void PerformKnockback(GameObject player)
    {
        if (!isKnockbackInProgress)
        {
            // Apply knockback force to the player
            Vector2 knockbackDirection = (player.transform.position - transform.position).normalized;
            Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();

            // Normalize the knockback force and apply the desired magnitude
            Vector2 knockbackForceVector = knockbackDirection * knockbackForce;

            // Reset the player's velocity to avoid accumulation of forces
            playerRigidbody.velocity = Vector2.zero;

            // Apply the knockback force
            playerRigidbody.AddForce(knockbackForceVector, ForceMode2D.Impulse);

            // Debug message
            Debug.Log("Boss performs knockback!");

            // Set flag to indicate knockback is in progress
            isKnockbackInProgress = true;

            // Reset knockback readiness and set a timer to reset readiness after the cooldown
            isKnockbackReady = false;
            Invoke("ResetKnockbackReadiness", knockbackCooldown);
        }
    }



    private void ResetSlamAttackReadiness()
    {
        isSlamAttackReady = true;  // Set slam attack readiness to true after cooldown
    }

    private void ResetKnockbackReadiness()
    {
        isKnockbackReady = true;  // Set knockback readiness to true after cooldown
    }
}
