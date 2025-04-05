using UnityEngine;
using UnityEngine.Audio;

public class CollisionSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioMixerGroup audioMixerGroup;

    void Start()
    {
        // Initialize audioSource in Start()
        audioSource = GetComponent<AudioSource>();  // Ensure we have the AudioSource component

        // Debug log to confirm the AudioSource is found
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on " + gameObject.name);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug log to confirm collision is happening
      

        // Check if audioSource and clip are not null before playing the sound
        if (audioSource != null && audioSource.clip != null)
        {
            PlayAudioWithMixer(audioSource.clip, transform.position, audioSource.volume, audioMixerGroup);
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is missing on " + gameObject.name);
        }
    }

    private void PlayAudioWithMixer(AudioClip clip, Vector3 position, float volume, AudioMixerGroup mixerGroup)
    {
        // Create an empty GameObject to play the sound
        GameObject audioObject = new GameObject("TempAudio");
        AudioSource tempAudioSource = audioObject.AddComponent<AudioSource>();

        // Assign the clip and settings
        tempAudioSource.clip = clip;
        tempAudioSource.volume = volume;
        tempAudioSource.outputAudioMixerGroup = mixerGroup;
        tempAudioSource.Play();

        // Destroy the audio object after it has finished playing
        Destroy(audioObject, clip.length);
    }
}
