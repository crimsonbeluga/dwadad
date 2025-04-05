using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro; // Required for Slider

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public int score = 0; // Keeps track of the score
    public int deathTargetCount = 0; // Keeps track of the number of "DeathTargets"

    // UI States
    [SerializeField] private string GamePlayScene;
    [SerializeField] private string OptionsScene;
    [SerializeField] private string Main;
    [SerializeField] private string Credits;
    [SerializeField] private string VictoryScene;
    [SerializeField] private string GameOver;

    // Audio Management
    public List<AudioClip> SoundClips; // List of destroy sounds
    public float bulletDestroyVolume = 1.0f; // Volume level
    public AudioMixer audioMixer; // Reference to an Audio Mixer in Unity

    // References to Sliders
    public Slider mainVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    // Score UI Text Prefab
    [SerializeField] private GameObject scoreUITextPrefab;  // Reference to your Text prefab for displaying score
    private TextMeshProUGUI scoreUIText;  // Reference to the actual Text component from the prefab

    public float delayTime = 2f; // Delay before game over

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevents GameManager from being destroyed when switching scenes
            Debug.Log("GameManager instance created.");
        }
        else
        {
            Debug.LogWarning("Duplicate GameManager instance detected! Destroying extra instance.");
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // If the scoreUIText prefab is assigned and the prefab has not been instantiated yet
        if (scoreUIText == null && scoreUITextPrefab != null)
        {
            GameObject scoreUIInstance = Instantiate(scoreUITextPrefab); // Instantiate the prefab
            scoreUIText = scoreUIInstance.GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component
            scoreUIText.text = "Score: " + score; // Initialize score text to 0
            Debug.Log("Score UI Text instantiated and initialized.");
        }

        score = 0;
        UpdateScoreUI();  // Initialize the score UI

        // Load and set the volume sliders based on saved values
        LoadVolumeSettings();

        // Add listeners for each slider
        mainVolumeSlider.onValueChanged.AddListener(UpdateMainVolume);
        musicVolumeSlider.onValueChanged.AddListener(UpdateMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(UpdateSFXVolume);
    }

    // Load volume settings from PlayerPrefs
    private void LoadVolumeSettings()
    {
        // Load saved values from PlayerPrefs
        float mainVolume = PlayerPrefs.GetFloat("MainVolume", .5f); // Default to 1.0 (max volume)
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", .5f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", .5f);

        // Set the sliders to the loaded values (converting dB to 0-1 scale)
        mainVolumeSlider.value = Mathf.Pow(10, mainVolume / 20);
        musicVolumeSlider.value = Mathf.Pow(10, musicVolume / 20);
        sfxVolumeSlider.value = Mathf.Pow(10, sfxVolume / 20);
    }

    // Function to update Main Volume
    private void UpdateMainVolume(float value)
    {
        audioMixer.SetFloat("MainVolume", Mathf.Log10(value) * 20);
        // Save the volume to PlayerPrefs
        PlayerPrefs.SetFloat("MainVolume", value);
    }

    // Function to update Music Volume
    private void UpdateMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        // Save the volume to PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    // Function to update SFX Volume
    private void UpdateSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
        // Save the volume to PlayerPrefs
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    // Activate Title Screen
    public void ActivateTitleScreen()
    {
        SceneManager.LoadScene(Main); // Load the main scene
    }

    public void ActivateOptionsScreen()
    {
        SceneManager.LoadScene(OptionsScene);
    }

    public void ActivateCreditsScreen()
    {
        SceneManager.LoadScene(Credits);
    }

    public void ActivateGameplayState()
    {
        SceneManager.LoadScene(GamePlayScene);
    }

    public void WinGame()
    {
        Debug.Log("WinGame() called! Score: " + score);
        if (score >= 1) // ✅ Check for 1 instead of 10
        {
            Debug.Log("Loading Victory Scene...");
            SceneManager.LoadScene(VictoryScene); // Ensure VictoryScene is properly assigned in the inspector
        }
    }

    public void LoseGame()
    {
        // Implementation for LoseGame
    }

    void Update()
    {
        Debug.Log("AudioListener Volume: " + AudioListener.volume);
    }

    public AudioClip GetBulletDestroySound()
    {
        return SoundClips.Count > 0 ? SoundClips[0] : null;
    }

    public float GetBulletDestroyVolume()
    {
        return bulletDestroyVolume;
    }

    public void RegisterDeathTarget()
    {
        deathTargetCount++;
        Debug.Log("DeathTarget added. Total count: " + deathTargetCount);
    }

    public void UnregisterDeathTarget()
    {
        deathTargetCount = Mathf.Max(0, deathTargetCount - 1);
        Debug.Log("DeathTarget removed. Total count: " + deathTargetCount);
        if (deathTargetCount == 0)
        {
            // Do something if needed
        }
    }

    // Method to add score and update the UI
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreUI();  // Update the UI whenever the score changes
        Debug.Log("Score added! Current Score: " + score);

        
    }

    // Method to get the current score
    public int GetScore()
    {
        return score;
    }

    // Method to update the UI Text for the score
    private void UpdateScoreUI()
    {
        if (scoreUIText != null)
        {
            scoreUIText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("Score UI Text not assigned!");
        }
    }

    // Exit the game
    public void ExitGame()
    {
        Application.Quit();

        // IF running in unity editor, this will stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
