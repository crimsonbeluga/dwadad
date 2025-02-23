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

    [Header("Movement Settings")]
    public float movementSpeed = 3f;
    public float turboSpeed1 = 3f;
    public float turboSpeed2 = 3f;
    public float turnSpeed = 1.0f;

    [Header("Shooting Settings")]
    public GameObject Laser; // Assign the laser prefab in the Inspector

    [Header("Three-shot Spread Settings")]
    public float shotSpread = 0.5f; // Distance between the lasers in the spread

    void Update()
    {
        Transform tf = transform;

        // Apply turbo boost 
        float currentSpeed = movementSpeed;

        if (Input.GetKey(TurboBoostKey1))
            currentSpeed *= turboSpeed1;

        if (Input.GetKey(TurboBoostKey2))
            currentSpeed *= turboSpeed2;

        // Movement
        if (Input.GetKey(Left))
            tf.position += tf.TransformDirection(Vector3.left) * currentSpeed * Time.deltaTime;

        if (Input.GetKey(Right))
            tf.position += tf.TransformDirection(Vector3.right) * currentSpeed * Time.deltaTime;

        if (Input.GetKey(Up))
            tf.position += tf.TransformDirection(Vector3.up) * currentSpeed * Time.deltaTime;

        if (Input.GetKey(Down))
            tf.position += tf.TransformDirection(Vector3.down) * currentSpeed * Time.deltaTime;

        // Rotation
        if (Input.GetKey(RotateRight))
            tf.Rotate(Vector3.forward * -turnSpeed * Time.deltaTime);

        if (Input.GetKey(RotateLeft))
            tf.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);

        // Quit
        if (Input.GetKeyDown(quitKey))
            Application.Quit();

        // Shooting
        if (Input.GetKeyDown(shoot)) // Use GetKeyDown to fire once per key press
        {
            // Calculate the spawn position (1 unit in front of the object)
            Vector3 spawnPosition = transform.position + transform.up * 1f;

            // Instantiate the lasers with a spread
            Instantiate(Laser, spawnPosition + transform.right * -shotSpread, transform.rotation); // Left laser
            Instantiate(Laser, spawnPosition, transform.rotation); // Center laser
            Instantiate(Laser, spawnPosition + transform.right * shotSpread, transform.rotation); // Right laser
        }
    }
}
