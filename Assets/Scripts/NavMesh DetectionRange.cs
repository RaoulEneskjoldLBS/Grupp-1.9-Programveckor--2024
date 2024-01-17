using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public float initialDetectionRange = 5f; // The initial detection range
    public float maxDetectionRange = 10000f; // The maximum detection range when player is detected
    public LayerMask obstacleLayer; // The layer mask for obstacles in the navigation mesh

    private float currentDetectionRange; // The current detection range
    private bool playerDetected = false; // Flag to track if the player is detected

    private void Start()
    {
        currentDetectionRange = initialDetectionRange;
    }

    private void Update()
    {
        // Check for obstacles within the current detection range
        Collider2D[] obstacles = Physics2D.OverlapCircleAll(transform.position, currentDetectionRange, obstacleLayer);

        foreach (Collider2D obstacle in obstacles)
        {
            // Handle obstacle detection logic here
            if (obstacle.CompareTag("Player")) // Check if the detected object is the player
            {
                // Player detected, increase the detection range
                playerDetected = true;
                currentDetectionRange = maxDetectionRange;
            }
        }

        // Visualize the detection range in the Scene view
        Gizmos.color = playerDetected ? Color.red : Color.blue;
        Gizmos.DrawWireSphere(transform.position, currentDetectionRange);
    }
}
