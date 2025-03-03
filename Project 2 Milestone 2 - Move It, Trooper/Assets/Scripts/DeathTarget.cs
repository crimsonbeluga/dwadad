using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathTarget : DeathDestroy
{
    public TextMeshProUGUI countText; // Reference to the UI text to show the count
    public int pointValue = 1; // Point value for destroying the target (set to 1)

    private void Start()
    {
        if (countText != null)
        {
            SetCountText(); // Update the score display at the start
        }
        else
        {
            Debug.LogError("countText is not assigned in the Inspector!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with has the "Pickup" tag
        if (other.gameObject.CompareTag("Pickup"))
        {
            Debug.Log("Pickup detected! Adding points.");
            // Update the score in the GameManager
            GameManager.instance.AddScore(pointValue);
            // Update the score display
            SetCountText();
            // Destroy the pickup object
            Destroy(other.gameObject);
        }
    }

    // Function to update the displayed score
    void SetCountText()
    {
        if (countText != null)
        {
            // Update the text to show the current score from GameManager
            countText.text = "Score: " + GameManager.instance.GetScore().ToString();
            Debug.Log("Score Updated: " + GameManager.instance.GetScore()); // Debug log to confirm score update
        }
        else
        {
            Debug.LogWarning("countText reference is missing! Score won't display correctly.");
        }
    }
}
