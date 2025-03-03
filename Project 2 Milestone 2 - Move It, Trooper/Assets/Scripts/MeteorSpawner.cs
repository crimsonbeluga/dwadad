using OpenCover.Framework.Model;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab; // Reference to the meteor prefab
    public float minSpawnInterval = 1f; // Minimum interval between meteor spawns
    public float maxSpawnInterval = 3f; // Maximum interval between meteor spawns
    public float meteorSpeed = 5f;  // Speed of the meteor's downward movement

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
        // Random X position between -10 and 10
        float randomX = Random.Range(-10f, 10f);

        // Set Y and Z as per your requirement (Y = 8, Z = 0)
        Vector3 spawnPosition = new Vector3(randomX, 8f, 0f);

        // Instantiate the meteor at the spawn position
        GameObject meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);

        // Set the meteor to start moving downward
        Meteor meteorScript = meteor.GetComponent<Meteor>();
        meteorScript.SetSpeed(meteorSpeed);

        // Spawn a new meteor again after the random interval
        SpawnMeteorWithRandomInterval();
    }
}
