// 'using' is a directive that allows you to include other namespaces into your script. It makes classes and functions from those namespaces accessible. 
// 'UnityEngine' is a built-in namespace in Unity that contains classes for game development, such as handling input, transforms, and more.
using UnityEngine;

// 'public' is an access modifier, meaning this class can be accessed by other classes outside this script. 
// 'class' is a keyword in C# that is used to declare a class, which defines a blueprint for objects in the game. 
// 'PlayerController' is the name of this class, and it defines the behavior of the player controller. 
// The colon (':') indicates inheritance. This means 'PlayerController' is inheriting from 'MonoBehaviour', which is a base class provided by Unity.
// 'MonoBehaviour' is a Unity class that allows the 'PlayerController' class to attach to GameObjects and use Unity's event methods like 'Start()' and 'Update()'.
public class PlayerController : MonoBehaviour
{
    // '[Header("Teleportation Settings")]' is an attribute provided by Unity that adds a label in the Inspector in the Unity Editor.
    // It helps organize and label variables in the Inspector for better readability.
    [Header("Teleportation Settings")]

    // 'public' is an access modifier that makes this variable visible and editable in other scripts and in the Unity Inspector.
    // 'KeyCode' is a Unity enum that represents the different keys on the keyboard.
    // 'RandomTeleport' is a variable that holds the key assigned to trigger the random teleportation.
    public KeyCode RandomTeleport;  // Declare this at the class level, meaning it can be accessed and modified in other scripts.

    // The comment here explains that 'pawnScript' will hold a reference to another script attached to the same GameObject.
    // 'private' means the variable is only accessible within this class. 
    // 'Pawn' is the type of the script we want to reference. 
    // 'pawnScript' is the variable name that will store the reference to the 'Pawn' script component.
    private Pawn pawnScript;

    // 'void' is the return type of the 'Start()' method, indicating that it doesn't return any value. 
    // 'Start()' is a Unity method that is called once before the first frame of gameplay. It is used for initialization tasks.
    // This method is automatically called when the script is first attached to a GameObject.
    void Start()
    {
        // 'GetComponent<Pawn>()' is a Unity method that retrieves the attached 'Pawn' script component from the same GameObject.
        // 'pawnScript' is then assigned this component, allowing us to access its methods and properties.
        pawnScript = GetComponent<Pawn>();
    }

    // 'void' is the return type of the 'Update()' method, meaning it doesn't return anything. 
    // 'Update()' is another Unity-specific method that is called once per frame and is used for updating and checking every frame.
    // It is used here to check for player input each frame.
    void Update()
    {
        // This checks if the 'RandomTeleport' key (which was set by the user in the Inspector) is pressed down this frame.
        // 'Input.GetKeyDown()' is a Unity method that returns 'true' only once when the key is first pressed down.
        // 'RandomTeleport' is the key you want to use for teleporting.
        if (Input.GetKeyDown(RandomTeleport))
        {
            // 'pawnScript.TeleportRandomly()' calls the 'TeleportRandomly()' method from the 'Pawn' script that was referenced in 'pawnScript'.
            // This will make the pawn teleport to a random position, as defined in the 'Pawn' script.
            pawnScript.TeleportRandomly(); // Call the teleport method in Pawn script
        }
    }
}
