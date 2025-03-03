// 'using UnityEngine;' is a directive that allows us to include the UnityEngine namespace into this script. 
// This namespace contains essential Unity components and functions, such as Transform, MonoBehaviour, and many others that help control game objects and other parts of Unity.
// In this case, we need UnityEngine to access MonoBehaviour and other Unity features.
using UnityEngine;

// 'public' is an access modifier that makes the 'SpriteRotation' class accessible from other classes, scripts, or the Unity Inspector. 
// If we made it 'private', the class would only be accessible within this script, not from other scripts or the Unity Editor.
public class SpriteRotation : MonoBehaviour
{
    // 'private' is an access modifier that means this variable can only be accessed within this class. It cannot be accessed from outside this class.
    // 'Transform' is a Unity component that allows us to manipulate an object's position, rotation, and scale in 3D space.
    // 'tf' is the variable name that will hold the reference to the Transform component attached to this GameObject.
    private Transform tf; // Create a variable for our transform component

    // 'public' is an access modifier that makes this variable accessible from other scripts and visible in the Unity Inspector.
    // 'float' is a data type that represents a number with decimal places. In this case, it will store the turn speed in degrees per frame.
    // 'turnSpeed' is the name of the variable, which indicates the speed at which we will rotate the sprite.
    public float turnSpeed; // Create a variable for the degrees we rotate in one frame draw

    // 'void' is the return type for the 'Start()' method. It means this method doesn't return any value.
    // 'Start()' is a Unity event method that is automatically called once when the script is first run, right before the first frame is rendered. 
    // It is typically used to initialize variables and set up the game state.
    // The method name 'Start' is special in Unity; it's not just any method but a built-in Unity callback that gets triggered when the script starts.
    void Start()
    {
        // 'GetComponent<Transform>()' is a Unity method that retrieves the Transform component attached to the same GameObject.
        // The Transform component controls the position, rotation, and scale of the GameObject in the 3D space.
        // 'tf' is assigned this component, allowing us to manipulate the object's transform.
        tf = GetComponent<Transform>(); // Load our transform component into our variable
    }

    // 'void' is the return type for the 'Update()' method, indicating that it doesn't return any value.
    // 'Update()' is another Unity-specific method. It runs once per frame, making it perfect for regularly updating things like input handling, physics, or movement.
    // Since it's empty in this case, nothing happens here yet. You could add rotation logic inside 'Update()' to rotate the sprite every frame.
    void Update()
    {
        // The 'Update' method would typically be where you put the code to rotate the sprite using 'turnSpeed'.
    }
}
