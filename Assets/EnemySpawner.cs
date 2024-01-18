using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject spritePrefab;  // Drag your sprite prefab here
    public float spawnInterval = 30f; // Time interval in seconds

    private float timer = 0f;

    void Update()
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

    void SpawnSprite()
    {
        // Instantiate the sprite prefab at the spawner's position
        Instantiate(spritePrefab, transform.position, Quaternion.identity);
    }
}
