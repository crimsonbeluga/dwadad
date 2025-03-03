// 'using' is a directive that allows you to access classes from a specified namespace.
// 'UnityEngine' is a Unity-specific namespace that contains classes necessary for interacting with the Unity engine (e.g., MonoBehaviour, GameObject, Transform, etc.).
using UnityEngine;

// 'public' is an access modifier that means the class can be accessed from other scripts and outside of this file.
// 'class' is a keyword that defines a new class in C#. A class is a blueprint for creating objects that encapsulate data and behaviors.
// 'PawnMeteor' is the name of the class. It defines the behavior and properties of a specific type of pawn in the game, which is a meteor.
// ': Pawn' is inheritance. This means that 'PawnMeteor' inherits from the 'Pawn' class, so it can use all properties and methods from 'Pawn'.
// This allows 'PawnMeteor' to extend or modify functionality from the base 'Pawn' class.
public class PawnMeteor : Pawn
{
    // '[Header("Key Bindings")]' is an attribute used in Unity to create a visual header in the Inspector. 
    // This groups the key binding variables together under a label for easy identification.
    [Header("Key Bindings")]

    // 'public' makes the variable accessible from other scripts and editable in the Unity Inspector.
    // 'KeyCode' is a Unity enum representing keyboard keys.
    // 'quitKey', 'Left', 'Right', 'Up', 'Down', 'TurboBoostKey1', 'TurboBoostKey2', 'RotateRight', 'RotateLeft', 'shoot' are variables for the keys that control the actions of the pawn.
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

    // '[Header("Movement Settings")]' is another attribute to group variables under a section in the Inspector.
    [Header("Movement Settings")]

    // 'float' is a data type that holds decimal values.
    // 'movementSpeed', 'turboSpeed1', 'turboSpeed2', and 'turnSpeed' represent the movement speed, turbo speeds, and turn speed of the pawn.
    public float movementSpeed = 3f;
    public float turboSpeed1 = 3f;
    public float turboSpeed2 = 3f;
    public float turnSpeed = 1.0f;

    // '[Header("Shooting Settings")]' groups variables related to shooting under a label in the Inspector.
    [Header("Shooting Settings")]

    // 'GameObject' is a Unity class that represents any object in the scene.
    // 'Laser' is the variable to hold a reference to the laser prefab that will be fired.
    public GameObject Laser; // Assign the laser prefab in the Inspector

    // '[Header("Three-shot Spread Settings")]' creates a header for the shot spread variables.
    [Header("Three-shot Spread Settings")]

    // 'shotSpread' controls the spread distance between the lasers when shooting.
    public float shotSpread = 0.5f; // Distance between the lasers in the spread

    // 'void' means the method doesn't return any value.
    // 'Update' is a built-in Unity method that is called once per frame. It's commonly used to check for user input or continuously update the game state.
    void Update()
    {
        // 'Transform' is a Unity component that represents an object's position, rotation, and scale in space.
        // 'tf' is a variable storing the Transform of the current object (pawn).
        // 'transform' is a built-in property of MonoBehaviour that refers to the object's Transform component.
        Transform tf = transform;

        // 'float' is used to declare a variable that stores a floating-point number (decimal value).
        // 'currentSpeed' is a variable used to store the speed at which the pawn moves. It's initially set to the default movementSpeed.
        float currentSpeed = movementSpeed;

        // 'Input.GetKey' checks if a specific key is currently pressed.
        // 'TurboBoostKey1' is the key for the first turbo boost. If it's pressed, the speed is multiplied by 'turboSpeed1' to increase the speed.
        if (Input.GetKey(TurboBoostKey1))
            currentSpeed *= turboSpeed1;

        // 'TurboBoostKey2' is the key for the second turbo boost. If it's pressed, the speed is multiplied by 'turboSpeed2' to further increase the speed.
        if (Input.GetKey(TurboBoostKey2))
            currentSpeed *= turboSpeed2;

        // Movement section: checks which directional keys are pressed and moves the object in the respective direction.
        // 'Input.GetKey' checks if a specific key is being held down.
        // 'tf.position' represents the object's position in world space.
        // 'tf.TransformDirection' converts a local direction (e.g., Vector3.left) into a direction in world space.
        // 'Time.deltaTime' ensures that movement is frame rate independent, making the movement smooth across different frame rates.

        // Left movement: if the Left key is pressed, move the pawn left by multiplying the direction with speed and time.
        if (Input.GetKey(Left))
            tf.position += tf.TransformDirection(Vector3.left) * currentSpeed * Time.deltaTime;

        // Right movement: similar to left, but moves the pawn to the right.
        if (Input.GetKey(Right))
            tf.position += tf.TransformDirection(Vector3.right) * currentSpeed * Time.deltaTime;

        // Up movement: moves the pawn upward when the Up key is pressed.
        if (Input.GetKey(Up))
            tf.position += tf.TransformDirection(Vector3.up) * currentSpeed * Time.deltaTime;

        // Down movement: moves the pawn downward when the Down key is pressed.
        if (Input.GetKey(Down))
            tf.position += tf.TransformDirection(Vector3.down) * currentSpeed * Time.deltaTime;

        // Rotation section: checks if rotation keys are pressed and rotates the object accordingly.
        // 'tf.Rotate' rotates the object around a specific axis by the specified amount.
        // 'Vector3.forward' is the vector pointing in the positive Z direction in world space.
        // '-turnSpeed' rotates the pawn clockwise, while 'turnSpeed' rotates it counterclockwise.

        // Right rotation: rotate the pawn clockwise when the RotateRight key is pressed.
        if (Input.GetKey(RotateRight))
            tf.Rotate(Vector3.forward * -turnSpeed * Time.deltaTime);

        // Left rotation: rotate the pawn counterclockwise when the RotateLeft key is pressed.
        if (Input.GetKey(RotateLeft))
            tf.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);

        // Quit section: checks if the quit key is pressed. If it is, the application quits.
        // 'Input.GetKeyDown' checks if a key is pressed down, and it only triggers once for that press.
        // 'Application.Quit()' exits the application.
        if (Input.GetKeyDown(quitKey))
            Application.Quit();

        // Shooting section: checks if the shoot key is pressed, and if it is, fires lasers.
        // 'Input.GetKeyDown' is used so that the shooting action only happens once when the key is pressed.
        if (Input.GetKeyDown(shoot)) // Use GetKeyDown to fire once per key press
        {
            // 'spawnPosition' calculates the position in front of the pawn to spawn the lasers. It adds 1 unit to the object's position in the up direction.
            Vector3 spawnPosition = transform.position + transform.up * 1f;

            // Instantiate creates a new laser object in the scene at the specified position with the same rotation as the pawn.
            // 'shotSpread' defines how far apart the lasers are from each other.
            Instantiate(Laser, spawnPosition + transform.right * -shotSpread, transform.rotation); // Left laser
            Instantiate(Laser, spawnPosition, transform.rotation); // Center laser
            Instantiate(Laser, spawnPosition + transform.right * shotSpread, transform.rotation); // Right laser
        }
    }
}
