// 'using' is a directive that includes a namespace, allowing access to classes and functions within it.
// 'UnityEngine' is the namespace that provides Unity's core functionality, such as GameObjects, physics, and rendering.
using UnityEngine;

// 'public' is an access modifier that makes this class accessible from other scripts.
// 'abstract' is a keyword that indicates this class cannot be instantiated on its own and must be inherited by other classes.
// 'class' is a keyword that defines a new class, which is a blueprint for creating objects.
// 'Controller' is the name of this class. It must match the filename to avoid errors in Unity.
// ':' (colon) is used for inheritance, meaning this class extends another class.
// 'MonoBehaviour' is the base class from Unity that allows this script to be attached to GameObjects.
public abstract class Controller : MonoBehaviour
{
    // Curly braces '{' and '}' define the body of the class, enclosing all its members.

    // 'void' is the return type, meaning this method does not return any value.
    // 'Start' is a special Unity method that is called once before the first frame update.
    // Parentheses '()' are used to define parameters, though Start takes none.
    // The opening '{' and closing '}' define the method body.
    void Start()
    {
        // This block is currently empty but will execute once when the GameObject is created.
    }

    // 'void' is the return type, meaning this method does not return any value.
    // 'Update' is a special Unity method that is called once per frame.
    // This is where game logic like movement or checking for player input is often placed.
    void Update()
    {
        // This block is empty but executes every frame.
    }
} // This closing brace ends the class definition.
