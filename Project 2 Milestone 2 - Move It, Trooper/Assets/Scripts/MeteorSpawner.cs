using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public GameObject ufoPrefab;
    public GameObject alienMotherPrefab;

    [Header("Spawn Timing")]
    public float initialMinSpawnDelay = 3f;  // Starting minimum time between spawns
    public float initialMaxSpawnDelay = 5f;  // Starting maximum time between spawns
    public float minSpawnDelayLimit = 0.5f;  // Smallest possible delay between spawns
    public float spawnRateIncreaseFactor = 0.98f; // Controls how fast enemies spawn (1 = no change, <1 = speeds up)

    [Header("Spawn Chances")]
    public float ufoSpawnChance = 0.2f;       // 20% chance to spawn a UFO
    public float alienMotherSpawnChance = 0.05f; // 5% chance to spawn an Alien Mother

    [Header("Health Bar")]
    public GameObject healthBarPrefab; // Reference to the health bar prefab

    private float currentMinSpawnDelay;
    private float currentMaxSpawnDelay;

    void Start()
    {
        currentMinSpawnDelay = initialMinSpawnDelay;
        currentMaxSpawnDelay = initialMaxSpawnDelay;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float waitTime = Random.Range(currentMinSpawnDelay, currentMaxSpawnDelay);
            yield return new WaitForSeconds(waitTime);

            SpawnObject();

            // Gradually decrease the spawn delay over time, making enemies spawn faster
            currentMinSpawnDelay = Mathf.Max(minSpawnDelayLimit, currentMinSpawnDelay * spawnRateIncreaseFactor);
            currentMaxSpawnDelay = Mathf.Max(minSpawnDelayLimit, currentMaxSpawnDelay * spawnRateIncreaseFactor);
        }
    }

    void SpawnObject()
    {
        int spawnType = Random.Range(0, 3);
        Vector3 spawnPosition = Vector3.zero;
        Vector2 movementDirection = Vector2.zero;

        if (spawnType == 0)
        {
            float randomX = Random.Range(-10f, 10f);
            spawnPosition = new Vector3(randomX, 8f, 0f);
            movementDirection = Vector2.down;
        }
        else if (spawnType == 1)
        {
            float randomY = Random.Range(-6f, 8f);
            spawnPosition = new Vector3(-13f, randomY, 0f);
            movementDirection = Vector2.right;
        }
        else
        {
            float randomY = Random.Range(-6f, 8f);
            spawnPosition = new Vector3(13f, randomY, 0f);
            movementDirection = Vector2.left;
        }

        GameObject spawnedObject;
        float randomValue = Random.value;

        if (randomValue < alienMotherSpawnChance)
        {
            spawnedObject = Instantiate(alienMotherPrefab, spawnPosition, Quaternion.identity);
        }
        else if (randomValue < ufoSpawnChance + alienMotherSpawnChance)
        {
            spawnedObject = Instantiate(ufoPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            spawnedObject = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);

            // Add MeteorLifetime script to the meteor
            MeteorLifetime meteorLifetime = spawnedObject.AddComponent<MeteorLifetime>();
            meteorLifetime.lifetime = 10f; // Set lifetime to 10 seconds
        }

        // Add the HealthBarFollow script to make the health bar follow the spawned object
        HealthBarFollow healthBarFollow = spawnedObject.AddComponent<HealthBarFollow>();
        healthBarFollow.healthBarPrefab = healthBarPrefab;

        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = movementDirection * 5f;
        }
    }

}
