// 'using' is a directive that allows you to use namespaces and access classes from them. 
// 'UnityEngine' is a namespace that includes Unity-specific classes (e.g., MonoBehaviour, Transform, Input, etc.).
using UnityEngine;

// 'public' is an access modifier that specifies that the class is accessible from other scripts. 
// This allows other scripts to interact with this class. 
// 'class' is a keyword that defines a new class in C#. 
// 'Pawn' is the name of the class. A class defines the behavior and properties of an object in the game.
public class Pawn : MonoBehaviour
{
    // '[Header("damage")]' is an attribute that adds a label in the Unity Inspector to organize and group variables. 
    // It provides a visual header "damage" for any variables under it in the Inspector.
    [Header("damage")]

    // '[Header("Teleportation Settings")]' adds a new section with a label "Teleportation Settings" in the Inspector.
    [Header("Teleportation Settings")]

    // 'public' makes these variables accessible from other scripts and Unity's Inspector.
    // 'KeyCode' is an enumeration that represents the keys on a keyboard.
    // Each variable holds a reference to the key that will trigger a teleportation action in different directions.
    // 'TeleportLeft', 'TeleportRight', 'TeleportUp', 'TeleportDown', and 'RandomTeleport' are the names of the variables.
    public KeyCode TeleportLeft;
    public KeyCode TeleportRight;
    public KeyCode TeleportUp;
    public KeyCode TeleportDown;
    public KeyCode RandomTeleport;

    // '[Header("Teleportation Bounds")]' is another header for organizing variables related to teleportation bounds in the Inspector.
    [Header("Teleportation Bounds")]

    // 'public' makes these variables accessible and editable in the Unity Inspector.
    // 'float' is a data type used to store decimal numbers (e.g., 1.23, 45.6).
    // 'xMin', 'xMax', 'yMin', 'yMax' are the names of the variables, defining the boundaries for teleportation.
    // 'teleportDistance' is the distance the pawn will teleport when a key is pressed, with a default value of 1200f.
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float teleportDistance = 1200f; // Adjustable teleport distance

    // 'void' means this method does not return a value. 'Start' is a built-in Unity method that is called once, before the first frame update.
    // It is used to initialize variables or states before the game starts.
    void Start()
    {
        // The Start method can be used for initialization, but it's empty here since no initialization is required in this case.
        // If needed, you can add any setup code here.
    }

    // 'void' means this method does not return a value. 'Update' is another built-in Unity method called every frame.
    // This is where we handle ongoing updates, such as checking for user input or making continuous changes.
    void Update()
    {
        // 'Transform' is a Unity component that represents an object's position, rotation, and scale in the scene.
        // 'tf' is a variable that holds a reference to the object's Transform.
        // 'transform' is a built-in property of MonoBehaviour that refers to the current GameObject's Transform.
        Transform tf = transform;

        // Teleportation controls:
        // 'Input.GetKeyDown' checks if the user pressed a key. If the key assigned to TeleportLeft is pressed:
        // 'tf.position' represents the object's position in 3D space.
        // 'tf.TransformDirection(Vector3.left)' transforms the direction into world space, ensuring that the teleportation happens in the correct direction.
        // 'teleportDistance' multiplies the direction vector to move the object by the specified distance.
        if (Input.GetKeyDown(TeleportLeft))
            tf.position += tf.TransformDirection(Vector3.left) * teleportDistance; // Teleports the pawn to the left

        // Similar code for teleporting the object to the right:
        if (Input.GetKeyDown(TeleportRight))
            tf.position += tf.TransformDirection(Vector3.right) * teleportDistance; // Teleports the pawn to the right

        // Similar code for teleporting the object upwards:
        if (Input.GetKeyDown(TeleportUp))
            tf.position += tf.TransformDirection(Vector3.up) * teleportDistance; // Teleports the pawn upwards

        // Similar code for teleporting the object downwards:
        if (Input.GetKeyDown(TeleportDown))
            tf.position += tf.TransformDirection(Vector3.down) * teleportDistance; // Teleports the pawn downwards
    }

    // 'public' allows this method to be called from other scripts.
    // 'void' means this method doesn't return a value.
    // 'TeleportRandomly' is the name of the method, and it will handle teleporting the object to a random location.
    public void TeleportRandomly()
    {
        // 'Transform tf = transform;' stores the reference to the pawn's Transform component, which is used to change its position and rotation.
        Transform tf = transform;

        // 'Vector3' is a structure representing a point in 3D space (x, y, z).
        // 'Random.Range(xMin, xMax)' generates a random float number between xMin and xMax for the x-coordinate.
        // 'Random.Range(yMin, yMax)' generates a random float number between yMin and yMax for the y-coordinate.
        // The z-coordinate is set to 0 because we are only concerned with 2D teleportation.
        Vector3 position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);

        // 'tf.SetPositionAndRotation(position, Quaternion.identity);' sets the object's position and rotation.
        // 'Quaternion.identity' represents no rotation (default rotation), meaning the object’s rotation will not change.
        tf.SetPositionAndRotation(position, Quaternion.identity); // Set the new position and reset rotation
    }
}
