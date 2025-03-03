// The 'using' directive allows you to use namespaces or assemblies in your script. This line includes the UnityEngine namespace, which is essential for accessing Unity-specific functions and classes, such as MonoBehaviour, Collider2D, and other Unity-related classes.
using UnityEngine;

// 'public' is an access modifier that determines the visibility of the class to other scripts or components. In this case, 'public' means that the 'Obstacle' class is accessible from other scripts and can be attached to GameObjects in Unity.
public class Obstacle : MonoBehaviour
{
    // The '[Header]' attribute is used to add a label above the field in Unity's Inspector. This is for organizational purposes, and the label "Obstacle Settings" will appear above the fields in the Inspector.
    [Header("Obstacle Settings")]

    // 'public' means that this variable is accessible from other scripts or components.
    // 'int' is the data type, meaning this variable will store integers (whole numbers).
    // 'damageAmount' is the name of the variable, used to represent the amount of damage an obstacle can deal.
    // '= 1' initializes the variable with a default value of 1.
    public int damageAmount = 1;  // Amount of damage dealt

    // 'bool' is the data type, which stands for Boolean, meaning it can only hold two values: true or false.
    // 'instantKill' is the name of the variable, used to determine whether the obstacle instantly kills the object it collides with.
    // '= false' initializes it to false, meaning the object will not be killed instantly by default.
    public bool instantKill = false;  // If true, kills any object on collision

    // This is a method declaration. 
    // 'public' means that the method can be accessed from other scripts or components.
    // 'void' means that the method does not return a value.
    // 'OnTriggerEnter2D' is the name of the method, a special Unity method that is called when a collider enters a trigger collider.
    // '(Collider2D other)' specifies that the method takes one parameter, which is a 2D collider (a component that represents colliders in 2D space).
    public void OnTriggerEnter2D(Collider2D other)
    {
        // 'health' is the type of the component we're looking for, which represents the health system of an object.
        // 'healthComponent' is the variable name, which will hold the reference to the health component of the object that collided with the obstacle.
        // 'other.GetComponent<health>()' looks for the health component on the object that collided with the obstacle.
        health healthComponent = other.GetComponent<health>();

        // This 'if' statement checks if the health component exists (is not null).
        // If the healthComponent is not null, then it means the collided object has a health system.
        if (healthComponent != null)
        {
            // 'if (instantKill)' checks if the 'instantKill' variable is set to true.
            // If true, it will immediately deal the full damage (the object's current health).
            if (instantKill)
            {
                // This calls the 'TakeDamage' method of the health component.
                // 'healthComponent.currentHealth' is passed in to deal all the current health as damage, effectively killing the object.
                healthComponent.TakeDamage(healthComponent.currentHealth); // Assuming TakeDamage handles death
            }
            else
            {
                // If 'instantKill' is false, it applies normal damage based on the 'damageAmount'.
                // 'TakeDamage(damageAmount)' applies the defined damage value to the health component.
                healthComponent.TakeDamage(damageAmount); // Apply damage
            }
        }
        else
        {
            // This block of code runs if the 'healthComponent' is null, meaning the object doesn't have a health component.
            // It logs a message to the console for debugging purposes.
            Debug.Log("Collided with an object without a Health component.");
        }
    }
}
