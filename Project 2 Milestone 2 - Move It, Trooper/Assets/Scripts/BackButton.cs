using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Button backButton; // Reference to the Back button

     public void Start()
    {
        // Ensure the button is assigned and add a listener
        if (backButton != null)
        {
            backButton.onClick.AddListener(ReturnToMainMenu);
        }
        else
        {
            Debug.LogError("Back button is not assigned in the Inspector.");
        }
    }

    public void ReturnToMainMenu()

    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateMainMenu(); // Calls the function to switch back to the main menu
        }
        else
        {
            Debug.LogError("GameManager instance not found!");
        }
    }
}
