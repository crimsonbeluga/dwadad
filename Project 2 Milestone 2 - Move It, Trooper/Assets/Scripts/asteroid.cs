using UnityEngine;

public class Asteroid : MonoBehaviour
{
    void Start()
    {
        // Initialization logic can go here if needed
    }

    void Update()
    {
        // Movement or other updates for the asteroid
    }

    // Detects when another 2D object collides with this asteroid
    public void OnTriggerEnter2D(Collider2D other)
    {
        // If the asteroid is hit, handle the collision (you could deal damage or destroy it)
        // Example: check for specific object type
        health healthComponent = other.GetComponent<health>();

        if (healthComponent != null)
        {
            // Example: Apply damage or kill the health component
            healthComponent.TakeDamage(1); // Assuming TakeDamage handles the death logic
            // Destroy asteroid on hit
            Destroy(gameObject);
        }
    }
}
