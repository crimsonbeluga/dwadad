using UnityEngine;  // Unity's core functionality
using System.Collections.Generic;  // To use Lists

public class LevelData : MonoBehaviour
{
    [Header("SpawnSettings")]
    public int SpawnRangeMin = 1;  // Minimum number of spawn points to spawn objects
    public int SpawnRangeMax = 10; // Maximum number of spawn points to spawn objects

    [Header("HeightLimitSettings")]
    public int heightLimit = 100;


    // Declare a public List of Transforms to store all the spawn points in the scene
    public List<Transform> spawnPoints = new List<Transform>();

    // The 'Awake' method is automatically called when the script instance is loaded
    void Awake()
    {
        // Clear the spawnPoints list to remove any previously stored values in case the scene is reloaded
        spawnPoints.Clear();

        // Find all GameObjects in the scene with the tag "spawnPoint"
        GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag("spawnPoint");

        // Add each GameObject's Transform to the 'spawnPoints' list
        foreach (GameObject spawnObject in spawnObjects)
        {
            spawnPoints.Add(spawnObject.transform); // Add the Transform component (position, rotation, scale)
        }

        // Log the number of spawn points found in the scene
        Debug.Log("Found " + spawnPoints.Count + " spawn points in the scene.");

        // Call the method to spawn a random number of spawn points
        SpawnRandomAmount();
    }

    private void Update()
    {
        spawnAtHeightLimit();
    }
    // Method to randomly spawn a number of spawn points
    public void SpawnRandomAmount()
    {
        // Generate a random number between SpawnRangeMin and SpawnRangeMax
        int randomSpawnCount = Random.Range(SpawnRangeMin, SpawnRangeMax + 1); // +1 so it can reach the maximum value

        // Log the random number of spawn points selected
        Debug.Log("Spawning " + randomSpawnCount + " random spawn points.");

        // Randomly select spawn points to activate (spawn their objects)
        for (int i = 0; i < randomSpawnCount; i++)
        {
            // Pick a random spawn point from the list
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            // Call the Spawn method on that spawn point
            spawnScript spawnScriptComponent = randomSpawnPoint.GetComponent<spawnScript>();
            if (spawnScriptComponent != null)
            {
                spawnScriptComponent.Spawn();  // Call the spawn method to spawn the object
            }
        }
    }

    private void spawnAtHeightLimit()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null && player.transform.position.y >= 100f)
        {
            player.transform.position = new Vector3(player.transform.position.x, heightLimit, player.transform.position.z);
        }
    }
}
