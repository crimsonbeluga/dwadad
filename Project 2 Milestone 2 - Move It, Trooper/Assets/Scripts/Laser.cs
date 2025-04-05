using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the laser collided with a valid object (like a target)
        if (other.CompareTag("Pickup"))  // Check for Pickup tag
        {
            // Increase the score when the laser hits a Pickup
            ScoreManager.instance.IncreaseScore();
        }
        else if (other.CompareTag("UFO"))  // Check for UFO tag
        {
            // Increase the score twice when the laser hits a UFO
            ScoreManager.instance.IncreaseScore();
            ScoreManager.instance.IncreaseScore();
        }

        else if (other.CompareTag("AlienMother"))  // Check for UFO tag
        {
            // Increase the score twice when the laser hits a UFO
            ScoreManager.instance.IncreaseScore();
            ScoreManager.instance.IncreaseScore();
            ScoreManager.instance.IncreaseScore();
        }
    }
}
