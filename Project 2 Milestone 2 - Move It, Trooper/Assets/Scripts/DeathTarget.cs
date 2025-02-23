using UnityEngine;

public class DeathTarget : DeathDestroy
{
    private void Start()
    {
        // Register this instance with the GameManager when created
        if (GameManager.instance != null)
        {
            GameManager.instance.RegisterDeathTarget();
        }
    }

    public override void Die()
    {
        // Unregister before destruction
        if (GameManager.instance != null)
        {
            GameManager.instance.UnregisterDeathTarget();
        }

        // Call base Die() to destroy the object
        base.Die();
    }

    private void OnDestroy()
    {
        // Ensure it gets unregistered if destroyed outside Die()
        if (GameManager.instance != null)
        {
            GameManager.instance.UnregisterDeathTarget();
        }
    }
}
