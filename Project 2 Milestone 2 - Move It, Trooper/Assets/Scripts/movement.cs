// 'using' directives allow access to external namespaces, which provide additional functionality.
// 'System.Collections' is a namespace that provides support for data structures like lists and arrays.
using System.Collections;

// 'System.Collections.Generic' expands upon 'System.Collections' to support generic collections like List<T>.
using System.Collections.Generic;

// 'UnityEngine' is a namespace that contains Unity's core functionalities, including GameObjects, physics, and rendering.
using UnityEngine;

// 'public' is an access modifier that makes this class accessible from other scripts.
// 'class' is a keyword that defines a new class, which acts as a blueprint for creating objects.
// 'NewMonoBehaviourScript' is the name of this class and should match the filename in Unity.
// ':' (colon) indicates that this class inherits from another class.
// 'MonoBehaviour' is the base class that allows this script to be attached to a GameObject in Unity.
public class NewMonoBehaviourScript : MonoBehaviour
{
    // 'public' makes these variables accessible from other scripts.
    // 'KeyCode' is a Unity-specific type that represents keyboard keys.
    // 'keypress' stores a key that will be used for an action in the game.
    public KeyCode keypress;

    // 'quitKey' stores a key that will be used to quit the application.
    public KeyCode quitKey;

    // 'public' makes these variables accessible from other scripts.
    // 'float' is a data type that represents a number with decimals.
    // 'xMin', 'xMax', 'yMin', and 'yMax' define boundaries for positioning the object.
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // 'void' is the return type, meaning this method does not return a value.
    // 'Start' is a built-in Unity method that is called once before the first frame update.
    void Start()
    {
        // This method is empty, but it can be used to initialize variables or set up game logic.
    }

    // 'void' is the return type, meaning this method does not return a value.
    // 'Update' is a built-in Unity method that is called once per frame.
    void Update()
    {
        // 'if' is a conditional statement that checks if a certain condition is true.
        // 'Input.GetKeyDown(keypress)' checks if the specified key was just pressed down this frame.
        if (Input.GetKeyDown(keypress))
        {
            // 'Vector3' is a Unity struct that represents a 3D position (x, y, z).
            // 'Random.Range(xMin, xMax)' generates a random float between 'xMin' and 'xMax'.
            // 'Random.Range(yMin, yMax)' generates a random float between 'yMin' and 'yMax'.
            // The z-axis is set to 0 since this is likely a 2D game.
            Vector3 position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);

            // 'transform' is a reference to the object's Transform component.
            // 'SetPositionAndRotation' sets both the position and rotation of the object.
            // 'Quaternion.identity' means no rotation.
            transform.SetPositionAndRotation(position, Quaternion.identity);
        }

        // 'if' checks if the quit key is pressed.
        // 'Input.GetKeyDown(quitKey)' returns true if the assigned quit key is pressed.
        if (Input.GetKeyDown(quitKey))
        {
            // 'Application.Quit()' closes the application. It only works in a built executable, not in the Unity editor.
            Application.Quit();
        }
    }
} // This closing brace ends the class definition.
