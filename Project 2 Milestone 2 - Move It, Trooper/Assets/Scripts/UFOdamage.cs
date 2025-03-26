using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class UFODamage : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public int damageAmount = 1;  // Amount of damage dealt
    public bool instantKill = false;  // If true, kills any object on collision

    private AudioSource audioSource;
    public AudioMixerGroup audioMixerGroup;

    void Start()
    {
        // Initialize the AudioSource component (if attached on the same object)
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Example: If the colliding object is tagged "Laser", play audio before destruction
        if (other.CompareTag("Laser"))
        {
            // Ensure we have the AudioSource and that it has a clip assigned
            if (audioSource != null && audioSource.clip != null)
            {
                // Call PlayAudioWithMixer so the sound continues to play even after this object is destroyed
                PlayAudioWithMixer(audioSource.clip, transform.position, audioSource.volume, audioMixerGroup);
            }
        }

        // Check if the colliding object has a health component
        health healthComponent = other.GetComponent<health>();
        if (healthComponent != null)
        {
            if (instantKill)
            {
                healthComponent.TakeDamage(healthComponent.currentHealth); // Instant death
            }
            else
            {
                healthComponent.TakeDamage(damageAmount);
            }
        }
    }

    // Function to play audio with AudioMixer support on a temporary object
    private void PlayAudioWithMixer(AudioClip clip, Vector3 position, float volume, AudioMixerGroup mixerGroup)
    {
        // Create an empty GameObject to host the AudioSource
        GameObject audioObject = new GameObject("TempAudio");
        // Set the position of the temporary audio object
        audioObject.transform.position = position;
        AudioSource tempAudioSource = audioObject.AddComponent<AudioSource>();

        // Assign the clip and audio settings
        tempAudioSource.clip = clip;
        // Increase volume with a multiplier to make it louder (adjust multiplier as needed)
        tempAudioSource.volume = Mathf.Clamp(volume * 2.0f, 0f, 1f);
        tempAudioSource.outputAudioMixerGroup = mixerGroup;
        // Use 2D sound (spatialBlend = 0) so volume doesn't decrease with distance
        tempAudioSource.spatialBlend = 0.0f;
        tempAudioSource.Play();

        // Destroy the temporary audio object after the clip has finished playing 
        Destroy(audioObject, clip.length);
    }
}
