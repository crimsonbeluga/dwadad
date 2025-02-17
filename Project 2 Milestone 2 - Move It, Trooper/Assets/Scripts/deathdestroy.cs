using UnityEngine;

public class DeathDestroy : Death
{
    // Override the Die method to destroy the GameObject
    public override void Die()
    {
        Debug.Log("Destroying the object...");
        Destroy(gameObject);  // Destroys the GameObject this component is attached to
    }
}
