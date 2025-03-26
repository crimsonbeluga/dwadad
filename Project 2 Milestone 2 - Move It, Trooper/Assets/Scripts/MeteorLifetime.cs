using UnityEngine;

public class MeteorLifetime : MonoBehaviour
{
    public float lifetime = 10f; // Lifetime of the meteor in seconds

    private void Start()
    {
        // Destroy the meteor after the specified lifetime
        Destroy(gameObject, lifetime);
    }
}
