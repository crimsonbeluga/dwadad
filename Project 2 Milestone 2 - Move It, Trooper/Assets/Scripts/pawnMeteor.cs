using UnityEngine;

public class PawnMeteor : Pawn
{
    [Header("Key Bindings")]
    public KeyCode quitKey;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode TurboBoostKey1;
    public KeyCode TurboBoostKey2;
    public KeyCode RotateRight;
    public KeyCode RotateLeft;
    public KeyCode shoot;

    public AudioClip fireSound;
    public float soundVolume = 1.0f;

    [Header("Movement Settings")]
    public float movementSpeed = 3f;
    public float turboSpeed1 = 3f;
    public float turboSpeed2 = 3f;
    public float turnSpeed = 1.0f;

    [Header("Shooting Settings")]
    public GameObject Laser;

    [Header("Three-shot Spread Settings")]
    public float shotSpread = 0.5f;

    private float bulletMaxDistance = 20f;

    private AudioSource audioSource; // AudioSource for playing sound

    void Start()
    {
        // Ensure we have an AudioSource attached to the GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource if not present
        }

        // Set the audio source to 3D audio
        audioSource.spatialBlend = 1.0f;  // 1.0 = 3D sound
        audioSource.minDistance = 1f; // Minimum distance to hear the sound at full volume
        audioSource.maxDistance = 50f; // Maximum distance before the sound fades
        audioSource.rolloffMode = AudioRolloffMode.Linear; // Linear falloff (distance based)
    }

    void Update()
    {
        Transform tf = transform;
        float currentSpeed = movementSpeed;

        if (Input.GetKey(TurboBoostKey1))
            currentSpeed *= turboSpeed1;

        if (Input.GetKey(TurboBoostKey2))
            currentSpeed *= turboSpeed2;

        Vector3 newPosition = tf.position;

        if (Input.GetKey(Left))
            newPosition += tf.TransformDirection(Vector3.left) * currentSpeed * Time.deltaTime;

        if (Input.GetKey(Right))
            newPosition += tf.TransformDirection(Vector3.right) * currentSpeed * Time.deltaTime;

        if (Input.GetKey(Up))
            newPosition += tf.TransformDirection(Vector3.up) * currentSpeed * Time.deltaTime;

        if (Input.GetKey(Down))
            newPosition += tf.TransformDirection(Vector3.down) * currentSpeed * Time.deltaTime;

        // Clamping position to stay within defined boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, -11f, 11f);
        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 6f);
        tf.position = newPosition;

        if (Input.GetKey(RotateRight))
            tf.Rotate(Vector3.forward * -turnSpeed * Time.deltaTime);

        if (Input.GetKey(RotateLeft))
            tf.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);

        if (Input.GetKeyDown(quitKey))
            Application.Quit();

        if (Input.GetKeyDown(shoot))
        {
            // Play the fire sound when shooting at the pawn's position in 3D space
            if (fireSound != null && audioSource != null)
            {
                // Update the audio source's position to the player pawn's position
                audioSource.transform.position = transform.position;

                // Play the fire sound with the adjusted volume
                audioSource.PlayOneShot(fireSound, soundVolume);
            }

            // Spawn bullets
            Vector3 spawnPosition = transform.position + transform.up * 1f;
            SpawnBullet(spawnPosition + transform.right * -shotSpread);
            SpawnBullet(spawnPosition);
            SpawnBullet(spawnPosition + transform.right * shotSpread);
        }
    }

    private void SpawnBullet(Vector3 position)
    {
        GameObject bullet = Instantiate(Laser, position, transform.rotation);
        bullet.AddComponent<BulletLifetime>().Initialize(transform.position, bulletMaxDistance);
    }
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
