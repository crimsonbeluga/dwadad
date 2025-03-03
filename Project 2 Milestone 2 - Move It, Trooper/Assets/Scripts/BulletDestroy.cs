using UnityEngine;

public class BulletDestroy : Shooter
{
    // Called when the bullet collides with a trigger (meteor)
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy the object the bullet collided with
        Destroy(other.gameObject);

        // Destroy the bullet itself after impact
        Destroy(gameObject);
    }

    void Start()
    {
        // Initialization logic can go here
    }

    void Update()
    {
        // Movement logic can go here if needed
    }
}
