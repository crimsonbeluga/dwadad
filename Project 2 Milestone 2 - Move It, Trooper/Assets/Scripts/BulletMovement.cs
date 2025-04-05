// 'using' is a directive that includes a namespace, allowing access to classes and functions within it.
// 'UnityEngine' is the namespace that provides Unity's core functionality, such as GameObjects, physics, and rendering.
using UnityEngine;

// 'public' is an access modifier that makes this class accessible from other scripts.
// 'class' is a keyword that defines a new class, which is a blueprint for creating objects.
// 'BulletMovement' is the name of this class. It must match the filename to avoid errors in Unity.
// ':' (colon) is used for inheritance, meaning this class extends another class.
// 'Shooter' is the base class that 'BulletMovement' inherits from. This means 'BulletMovement' will have access to 'Shooter's properties and methods.
public class BulletMovement : Shooter
{
    // 'public' is an access modifier, meaning this variable can be accessed and modified from other scripts.
    // 'float' is a data type that stores decimal numbers.
    // 'bulletSpeed' is the name of the variable, representing how fast the bullet moves.
    // '=' assigns the initial value of 1.0f to 'bulletSpeed'. The 'f' suffix ensures it's treated as a float.
    public float bulletSpeed = 1.0f;

    // 'void' is the return type, meaning this method does not return any value.
    // 'Update' is a special Unity method that is called once per frame.
    // This is where game logic like movement or checking for player input is often placed.
    void Update()
    {
        // 'transform' is a built-in Unity property that represents the position, rotation, and scale of the GameObject this script is attached to.
        // '.' (dot operator) is used to access properties and methods of an object.
        // 'Translate()' is a method that moves the GameObject in a given direction.
        // 'new' is a keyword used to create a new instance of an object.
        // 'Vector3' is a structure that represents a point or direction in 3D space.
        // '(0, 1, 0)' represents a movement vector in the upward direction (Y-axis).
        // '*' (multiplication operator) is used to scale the movement by 'bulletSpeed'.
        // 'Time.deltaTime' ensures movement is frame rate independent by scaling the movement based on the time elapsed since the last frame.
        transform.Translate(new Vector3(0, 1, 0) * bulletSpeed * Time.deltaTime);
    }
} // This closing brace ends the class definition.
