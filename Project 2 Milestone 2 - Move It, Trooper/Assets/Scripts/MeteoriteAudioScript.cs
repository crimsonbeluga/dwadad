using UnityEngine;

public class MeteoriteAudioScript : MonoBehaviour
{
    [Header("Meteorite Audio Settings")]
    public AudioClip meteoriteSound;  // The sound to play continuously
    public float soundVolume = .05f; // Volume of the sound

    private AudioSource audioSource;  // AudioSource component

    void Start()
    {
        // Ensure there's an AudioSource attached to the Meteorite
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource if not present
        }

        // Set the audio source to loop and set the volume
        audioSource.clip = meteoriteSound;
        audioSource.loop = true;  // Loop the sound
        audioSource.volume = soundVolume;  // Set the volume
        audioSource.Play();  // Start the sound
    }
}
