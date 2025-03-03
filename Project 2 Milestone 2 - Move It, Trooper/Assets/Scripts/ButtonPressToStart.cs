// 'using' keyword is used to import namespaces, allowing access to other code libraries.
// UnityEngine is a namespace that includes essential Unity classes like MonoBehaviour, GameObject, etc.
using UnityEngine;

// 'public' is an access modifier that specifies the visibility of the class to other scripts. 
// 'public' means this class can be accessed and used by other classes in any part of the project.
public class ButtonPressToStart : MonoBehaviour
{
    // 'public' makes the method accessible outside of this class. 
    // 'void' indicates that this method does not return any value (i.e., no output).
    // 'Startgame' is the name of the method and is a convention in Unity to define what happens when a game starts.
    public void Startgame()
    {
        // The 'if' statement is used to check if a condition is true. 
        // It will execute the code inside the block if the condition evaluates to 'true'.
        if (GameManager.instance != null)
        {
            // 'Debug' is a class in Unity that helps output messages to the console for debugging.
            // 'Log' is a method inside Debug used to print simple messages.
            Debug.Log("Starting Game...");

            // 'GameManager.instance' refers to a singleton instance of the GameManager class.
            // This calls the ActivateGameplayState method of the GameManager instance to start the gameplay state.
            GameManager.instance.ActivateGameplayState();
        }
        else
        {
            // 'Debug.LogError' is similar to Debug.Log, but it outputs an error message to the console.
            // This helps in identifying issues during development.
            Debug.LogError("GameManager instance is null! Make sure GameManager is in the scene.");
        }
    }
}
