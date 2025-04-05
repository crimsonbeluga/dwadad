// 'using' is a directive that includes a namespace, allowing access to classes and functions within it.
// 'UnityEngine' is the namespace that provides Unity's core functionality, such as GameObjects, physics, and rendering.
using UnityEngine;

// 'public' is an access modifier that makes this class accessible from other scripts.
// 'class' is a keyword that defines a new class, which is a blueprint for creating objects.
// 'DeathMoveToOrigin' is the name of this class. It must match the filename to avoid errors in Unity.
// ':' (colon) is used for inheritance, meaning this class extends another class.
// 'Death' is the base class that 'DeathMoveToOrigin' inherits from, meaning it must implement the abstract methods of 'Death'.
public class DeathMoveToOrigin : Death
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

    // 'public' is an access modifier, meaning this method can be accessed from other scripts.
    // 'override' is a keyword that indicates this method replaces an abstract or virtual method from the parent class.
    // 'void' is the return type, meaning this method does not return any value.
    // 'Die' is the name of the method, which overrides the abstract method from the 'Death' class.
    // Parentheses '()' indicate that this method does not take any parameters.
    public override void Die()
    {
        // 'transform' is a built-in Unity property that represents the position, rotation, and scale of the GameObject this script is attached to.
        // '.' (dot operator) is used to access properties and methods of an object.
        // 'position' is a property of 'transform' that represents the object's position in world space.
        // '=' (assignment operator) sets the position of the object.
        // 'Vector3' is a structure that represents a point or direction in 3D space.
        // 'zero' is a static property of Vector3 that returns the vector (0,0,0), meaning the world origin.
        transform.position = Vector3.zero; // Moves the object to (0,0,0)
    }
} // This closing brace ends the class definition.
