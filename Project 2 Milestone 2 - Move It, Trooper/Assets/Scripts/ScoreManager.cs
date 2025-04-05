using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0; // The current score
    public TextMeshProUGUI scoreText; // Reference to the UI TextMeshPro for displaying score

    private string victoryScene = "VictoryScene"; // Scene name for victory

    // Ensure there's only one ScoreManager
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to increase the score by 1
    public void IncreaseScore()
    {
        score += 1;
        UpdateScoreUI();

        Debug.Log("Score increased! Current score: " + score);

        // Check if score is 1 or more, then load VictoryScene
        if (score >= 300)
        {
            Debug.Log("Score reached 1! Loading Victory Scene...");
            SceneManager.LoadScene(victoryScene);
        }
    }

    // Method to update the score UI element
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned!");
        }
    }
}
