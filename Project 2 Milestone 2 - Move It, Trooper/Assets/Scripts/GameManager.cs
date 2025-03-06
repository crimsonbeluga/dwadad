using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI; // Required for Slider

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public int score = 0; // Keeps track of the score
    public int deathTargetCount = 0; // Keeps track of the number of "DeathTargets"

    // UI States
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;

    [SerializeField] private string SampleScene;
    [SerializeField] private string OptionsScene;
    [SerializeField] private string Main;
   

    // Audio Management
    public List<AudioClip> SoundClips; // List of destroy sounds
    public float bulletDestroyVolume = 1.0f; // Volume level
    public AudioMixer audioMixer; // Reference to an Audio Mixer in Unity

    // References to Sliders
    public Slider mainVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

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
        score = 0;
        Debug.Log("Score initialized to: " + score);

        // Ensure UI elements are properly set up
        if (MainMenuStateObject) MainMenuStateObject.SetActive(true);
        if (TitleScreenStateObject) TitleScreenStateObject.SetActive(true);

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

    private void SetInitialSliderValues()
    {
        // Initialize sliders to current values in AudioMixer
        float mainVolume, musicVolume, sfxVolume;
        audioMixer.GetFloat("MainVolume", out mainVolume);
        audioMixer.GetFloat("MusicVolume", out musicVolume);
        audioMixer.GetFloat("SFXVolume", out sfxVolume);

        // Set the sliders based on the values (converting dB to 0-1 scale)
        mainVolumeSlider.value = Mathf.Pow(10, mainVolume / 20);
        musicVolumeSlider.value = Mathf.Pow(10, musicVolume / 20);
        sfxVolumeSlider.value = Mathf.Pow(10, sfxVolume / 20);
    }

    // Function to update Main Volume
    private void UpdateMainVolumeWithDB(float value)
    {
        audioMixer.SetFloat("MainVolume", Mathf.Log10(value) * 20);
    }

    // Function to update Music Volume
    private void UpdateMusicVolumeWithDB(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    // Function to update SFX Volume
    private void UpdateSFXVolumeWithDB(float value)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
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
            WinGame();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        Debug.Log("Score added! Current Score: " + score);
    }

    public int GetScore()
    {
        return score;
    }

    public void DeactivateAllStates()
    {
        if (TitleScreenStateObject) TitleScreenStateObject.SetActive(false);
        if (OptionsScreenStateObject) OptionsScreenStateObject.SetActive(false);
        if (CreditsScreenStateObject) CreditsScreenStateObject.SetActive(false);
        if (GameplayStateObject) GameplayStateObject.SetActive(false);
        if (GameOverScreenStateObject) GameOverScreenStateObject.SetActive(false);

        // Keep Main Menu Active if returning to it
        if (MainMenuStateObject && SceneManager.GetActiveScene().name != OptionsScene)
        {
            MainMenuStateObject.SetActive(true);
        }
    }

    public void ActivateTitleScreen()
    {
        Debug.Log("Back button clicked - Attempting to load Title Screen: " + Main);

        DeactivateAllStates(); // Ensures all UI elements are reset

        if (!string.IsNullOrEmpty(Main))
        {
            SceneManager.LoadScene(Main);
        }
        else
        {
            Debug.LogError("Main scene name is not set! Assign it in the Inspector.");
        }
    }



    public void ActivateMainMenu()
    {
        DeactivateAllStates();
        if (MainMenuStateObject) MainMenuStateObject.SetActive(true);
    }

    public void ActivateOptionsScreen()
    {
        if (!string.IsNullOrEmpty(OptionsScene))
        {
            Debug.Log("Loading Options Scene: " + OptionsScene);
            SceneManager.LoadScene(OptionsScene);
        }
        else
        {
            Debug.LogError("OptionsScene name is not set! Assign it in the Inspector.");
        }
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

    void Update()
    {
        Debug.Log("AudioListener Volume: " + AudioListener.volume);
    }
}
