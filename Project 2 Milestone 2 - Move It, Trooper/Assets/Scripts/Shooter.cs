// 'using UnityEngine;' is a directive that brings in the UnityEngine namespace. This namespace contains a variety of classes and methods used in Unity, such as Transform, MonoBehaviour, and more.
// In this script, we are using 'UnityEngine' to gain access to Unity-specific functions and behaviors like MonoBehaviour lifecycle methods (Start, Update).
using UnityEngine;

// 'public' is an access modifier that makes this class visible and accessible to other scripts outside this one.
// It allows other scripts to access and interact with the 'Shooter' class. In Unity, this also allows it to appear in the Unity Inspector.
// 'class' is a keyword that defines a new class. A class is a blueprint for creating objects (or instances) in the program, and it encapsulates data and behavior for those objects.
// 'Shooter' is the name of this class. It represents a game object that has shooting behavior. 
// You can name your class anything, but by convention, it's good to use a name that describes the purpose of the class.
// The colon (':') signifies inheritance. This means 'Shooter' is inheriting from 'MonoBehaviour', which is a base class provided by Unity that allows this script to attach to a GameObject and interact with Unity's event methods.
public class Shooter : MonoBehaviour
{
    // The comment above explains the 'Start()' method, which is automatically called once when the script is first run, before the first frame is rendered.
    // 'Start()' is used for initialization. It is often used to set up things like variables or game states at the beginning of the script execution.
    // 'void' is the return type for the method. It indicates that this method does not return any value.
    // 'Start()' is a Unity-specific method used for initialization tasks.
    void Start()
    {
        // The 'Start' method is empty in this case. You would typically put code here to initialize variables or set up anything that needs to be prepared before the game starts.
    }

    // The comment above explains the 'Update()' method, which is automatically called once per frame.
    // 'Update()' is used for continuously updating behaviors or checking conditions that should be evaluated every frame, such as player input, movement, or physics.
    // 'void' is the return type, meaning this method does not return any value.
    // 'Update()' is called once per frame, making it suitable for real-time checks.
    void Update()
    {
        // The 'Update' method is empty in this case. You would typically put code here to check for player input, update object positions, or perform other tasks that need to be updated regularly.
    }
}
