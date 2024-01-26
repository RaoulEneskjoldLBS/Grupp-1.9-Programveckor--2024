using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject spritePrefab;  // Drag your sprite prefab here
    public float spawnInterval = 30f; // Time interval in seconds
    public float detectionRange = 10f; // Detection range for the player

    private float timer = 0f;
    private Transform playerTransform;

    void Start()
    {
        // Assuming the player has a "Player" tag. Adjust the tag accordingly.
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found. Make sure the player has the correct tag.");
        }
    }

    void Update()
    {
        // Check if the player is in detection range
        if (IsPlayerInDetectionRange())
        {
            // Update the timer
            timer += Time.deltaTime;

            // Check if the timer has reached the spawn interval
            if (timer >= spawnInterval)
            {
                // Spawn the sprite
                SpawnSprite();

                // Reset the timer
                timer = 0f;
            }
        }
    }

    bool IsPlayerInDetectionRange()
    {
        // Check if the player transform is valid and within the detection range
        return (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) <= detectionRange);
    }

    void SpawnSprite()
    {
        // Instantiate the sprite prefab at the spawner's position
        Instantiate(spritePrefab, transform.position, Quaternion.identity);
    }
}