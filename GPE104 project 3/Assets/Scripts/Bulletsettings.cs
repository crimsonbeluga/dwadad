using UnityEngine;

public class Bulletsettings : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject laserPrefab;
    public float shotSpread = 0.5f;
    public float bulletSpeed = 20f;
    public float bulletMaxDistance = 20f;

    public void HandleShooting()
    {

        {
            // Corrected sp awn positions for the bullets
            Vector3 spawnPosition = transform.position + transform.up * 1f;
            SpawnBullet(spawnPosition); // Center bullet
           
        }
    }

    private void SpawnBullet(Vector3 position)
    {
        // Instantiate the bullet 40 units to the left (subtract from the x-coordinate)
        Vector3 spawnPosition = position - new Vector3(0f, 0f, 0f);

        GameObject bullet = Instantiate(laserPrefab, spawnPosition, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = transform.TransformDirection(Vector3.forward) * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("Rigidbody is missing from the bullet prefab!");
        }

        BulletLifetime bulletLifetime = bullet.AddComponent<BulletLifetime>();
        bulletLifetime.Initialize(transform.position, bulletMaxDistance);
    }

    public class BulletLifetime : MonoBehaviour
    {
        private Vector3 originPosition;
        private float maxDistance;

        public void Initialize(Vector3 origin, float distance)
        {
            originPosition = origin;
            maxDistance = distance;
        }

        void Update()
        {
            if (Vector3.Distance(transform.position, originPosition) > maxDistance)
            {
                Destroy(gameObject);
            }
        }

    }
}
