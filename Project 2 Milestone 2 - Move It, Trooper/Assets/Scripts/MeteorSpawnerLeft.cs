using UnityEngine;

public class MeteorSpawnerLeft : MonoBehaviour
{
    public GameObject meteorPrefab;  // Reference to the meteor prefab
    public float minSpawnInterval = 1f;  // Minimum interval between meteor spawns
    public float maxSpawnInterval = 3f;  // Maximum interval between meteor spawns
    public float meteorSpeed = 5f;  // Speed of the meteor's rightward movement

    private void Start()
    {
        // Start spawning meteors with random intervals
        SpawnMeteorWithRandomInterval();
    }

    // Method to spawn meteor with random interval
    void SpawnMeteorWithRandomInterval()
    {
        // Randomize the interval between spawns
        float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

        // Call the SpawnMeteor method after the randomized interval
        Invoke("SpawnMeteor", randomInterval);
    }

    // Spawn a meteor at a random position
    void SpawnMeteor()
    {
        // Random y position between -6 and 8
        float randomY = Random.Range(-6f, 8f);

        // Set x as -13 (left side), random Y between -6 and 8, Z = 0
        Vector3 spawnPosition = new Vector3(-13f, randomY, 0f);

        // Instantiate the meteor at the spawn position
        GameObject meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);

        // Apply a movement to the meteor (Rightward motion)
        Rigidbody2D meteorRb = meteor.GetComponent<Rigidbody2D>();  // Using Rigidbody2D for 2D physics
        if (meteorRb != null)
        {
            meteorRb.linearVelocity = new Vector2(meteorSpeed, 0f);  // Move towards the right
        }

        // Check if meteor has moved past X = 14, and destroy it if true
        Destroy(meteor, 10f);  // Optional: Destroy after 20 seconds as a safety measure
        SpawnMeteorWithRandomInterval();
    }
}
