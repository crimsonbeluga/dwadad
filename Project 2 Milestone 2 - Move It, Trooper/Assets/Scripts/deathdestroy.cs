// 'using' is a directive that includes a namespace, allowing access to classes and functions within it.
// 'UnityEngine' is the namespace that provides Unity's core functionality, such as GameObjects, physics, and rendering.
using UnityEngine;

// 'public' is an access modifier that makes this class accessible from other scripts.
// 'class' is a keyword that defines a new class, which is a blueprint for creating objects.
// 'DeathDestroy' is the name of this class. It must match the filename to avoid errors in Unity.
// ':' (colon) is used for inheritance, meaning this class extends another class.
// 'Death' is the base class that 'DeathDestroy' inherits from, meaning it must implement the abstract methods of 'Death'.
public class DeathDestroy : Death
{
    // Curly braces '{' and '}' define the body of the class, enclosing all its members.

    // 'public' is an access modifier, meaning this method can be accessed from other scripts.
    // 'override' is a keyword that indicates this method replaces an abstract or virtual method from the parent class.
    // 'void' is the return type, meaning this method does not return any value.
    // 'Die' is the name of the method, which overrides the abstract method from the 'Death' class.
    // Parentheses '()' indicate that this method does not take any parameters.
    public override void Die()
    {
        // 'Debug.Log' is a method used to print messages to the Unity console for debugging.
        // The message "Destroying the object..." is displayed in the console when this method runs.
        Debug.Log("Destroying the object...");

        // 'Destroy' is a built-in Unity method that removes a GameObject from the scene.
        // 'gameObject' refers to the GameObject that this script is attached to.
        // ';' (semicolon) marks the end of the statement.
        Destroy(gameObject);
    }
} // This closing brace ends the class definition.
