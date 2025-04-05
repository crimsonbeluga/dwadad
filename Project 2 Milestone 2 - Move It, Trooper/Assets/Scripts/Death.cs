// 'using' is a directive that includes a namespace, allowing access to classes and functions within it.
// 'UnityEngine' is the namespace that provides Unity's core functionality, such as GameObjects, physics, and rendering.
using UnityEngine;

// 'public' is an access modifier that makes this class accessible from other scripts.
// 'abstract' is a keyword that indicates this class cannot be instantiated on its own and must be inherited by other classes.
// 'class' is a keyword that defines a new class, which is a blueprint for creating objects.
// 'Death' is the name of this class. It must match the filename to avoid errors in Unity.
// ':' (colon) is used for inheritance, meaning this class extends another class.
// 'MonoBehaviour' is the base class from Unity that allows this script to be attached to GameObjects.
public abstract class Death : MonoBehaviour
{
    // Curly braces '{' and '}' define the body of the class, enclosing all its members.

    // 'public' is an access modifier, meaning this method can be accessed from other scripts.
    // 'abstract' is a keyword that forces child classes to implement this method.
    // 'void' is the return type, meaning this method does not return any value.
    // 'Die' is the name of the method, which will be implemented by child classes.
    // Parentheses '()' indicate that this method does not take any parameters.
    // Semicolon ';' marks the end of the method declaration since abstract methods do not have a body.
    public abstract void Die();
} // This closing brace ends the class definition.
