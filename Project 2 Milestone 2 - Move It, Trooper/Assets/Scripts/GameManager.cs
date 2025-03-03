using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public int score = 0; // Keeps track of the score
    public int deathTargetCount = 0; // Keeps track of the number of "DeathTargets"

    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;
    [SerializeField] private string SampleScene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager instance created.");
        }
        else
        {
            Debug.LogWarning("Duplicate GameManager instance destroyed!");
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        score = 0;  // Reset the score to 0 when the game starts
        Debug.Log("Score initialized to: " + score);  // Check the score at start-up
        ActivateTitleScreen();
    }



    // Register a new DeathTarget (for counting the number of targets in the game)
    public void RegisterDeathTarget()
    {
        deathTargetCount++;
        Debug.Log("DeathTarget added. Total count: " + deathTargetCount);
    }

    // Unregister a DeathTarget
    public void UnregisterDeathTarget()
    {
        deathTargetCount = Mathf.Max(0, deathTargetCount - 1);
        Debug.Log("DeathTarget removed. Total count: " + deathTargetCount);
        if (deathTargetCount == 0)
        {
            WinGame();
        }
    }

    // Score-related methods
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd; // Update the score
        Debug.Log("Score added! Current Score: " + score);  // Debug to check score update
    }

    // Get Score method
    public int GetScore()
    {
        return score; // Return the current score
    }

    // UI screen management
    public void DeactivateAllStates()
    {
        if (TitleScreenStateObject) TitleScreenStateObject.SetActive(false);
        if (MainMenuStateObject) MainMenuStateObject.SetActive(false);
        if (OptionsScreenStateObject) OptionsScreenStateObject.SetActive(false);
        if (CreditsScreenStateObject) CreditsScreenStateObject.SetActive(false);
        if (GameplayStateObject) GameplayStateObject.SetActive(false);
        if (GameOverScreenStateObject) GameOverScreenStateObject.SetActive(false);
    }

    public void ActivateTitleScreen()
    {
        DeactivateAllStates();
        if (TitleScreenStateObject) TitleScreenStateObject.SetActive(true);
    }

    public void ActivateMainMenu()
    {
        DeactivateAllStates();
        if (MainMenuStateObject) MainMenuStateObject.SetActive(true);
    }

    public void ActivateOptionsScreen()
    {
        DeactivateAllStates();
        if (OptionsScreenStateObject) OptionsScreenStateObject.SetActive(true);
    }

    public void ActivateCreditsScreen()
    {
        DeactivateAllStates();
        if (CreditsScreenStateObject) CreditsScreenStateObject.SetActive(true);
    }

    public void ActivateGameplayState()
    {
        DeactivateAllStates();
        if (GameplayStateObject) GameplayStateObject.SetActive(true);

        if (!string.IsNullOrEmpty(SampleScene))
        {
            Debug.Log("Loading Scene: " + SampleScene);
            SceneManager.LoadScene(SampleScene);
        }
        else
        {
            Debug.LogError("Scene name is not set! Assign it in the Inspector.");
        }
    }

    public void ActivateGameOverScreen()
    {
        DeactivateAllStates();
        if (GameOverScreenStateObject) GameOverScreenStateObject.SetActive(true);
    }

    public void WinGame()
    {
        Debug.Log("You Win!");
    }

    public void LoseGame()
    {
        Debug.Log("You Lose!");
    }
}
