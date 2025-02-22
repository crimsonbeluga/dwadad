using UnityEngine;

public class PawnMeteor : Pawn


{


    [Header("Key Bindings")]
    public KeyCode quitKey;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode TurboBoostKey1;  // First turbo boost key
    public KeyCode TurboBoostKey2;  // Second turbo boost key
    public KeyCode RotateRight;
    public KeyCode RotateLeft;

  

    [Header("Movement Settings")]
    public float movementSpeed = 3f;  // Normal speed
    public float turboSpeed1 = 3f; // First turbo boost multiplier
    public float turboSpeed2 = 3f; // Second turbo boost multiplier
    public float turnSpeed = 1.0f;

    void Update()
    {

      
           

        Transform tf = transform;

        // Apply turbo boost 
        float currentSpeed = movementSpeed;  // Start with normal speed

        // Check for turbo boost key 1
        if (Input.GetKey(TurboBoostKey1))
        {
            currentSpeed *= turboSpeed1; // Apply turbo multiplier
        }

        // Check for turbo boost key 2
        if (Input.GetKey(TurboBoostKey2))
        {
            currentSpeed *= turboSpeed2; // Apply turbo multiplier
        }

        // Move only when the key is held down
        if (Input.GetKey(Left))
        {
            tf.position += tf.TransformDirection(Vector3.left) * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(Right))
        {
            tf.position += tf.TransformDirection(Vector3.right) * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(Up))
        {
            tf.position += tf.TransformDirection(Vector3.up) * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(Down))
        {
            tf.position += tf.TransformDirection(Vector3.down) * currentSpeed * Time.deltaTime;
        }
        // Rotate controls
        if (Input.GetKey(RotateRight))
            tf.Rotate(Vector3.forward * -turnSpeed * Time.deltaTime); // Rotate around the Z-axis clockwise

        if (Input.GetKey(RotateLeft))
            tf.Rotate(Vector3.forward * turnSpeed * Time.deltaTime); // Rotate around the Z-axis counterclockwise
        // Quit the application
        if (Input.GetKeyDown(quitKey))
        {
            Application.Quit();
        }
        


    }
}
