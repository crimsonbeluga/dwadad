using UnityEngine;

public class BulletDestroy : Shooter
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy the object the bullet collides with
        Destroy(other.gameObject);

        // Optionally destroy the bullet itself after impact
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}