using UnityEngine;

public class MeteoriteAudioScript : MonoBehaviour
{
    

    public AudioSource audioSource;  // AudioSource component

    void Start()
    {
      


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            // Get the AudioSource
            audioSource = GetComponent<AudioSource>();

            if (audioSource != null)
            {
                // Create a separate GameObject for the audio
                GameObject audioHolder = new GameObject("TempAudio");
                AudioSource newAudioSource = audioHolder.AddComponent<AudioSource>();

                // Copy AudioSource settings
                newAudioSource.clip = audioSource.clip;
                newAudioSource.volume = audioSource.volume;
                newAudioSource.pitch = audioSource.pitch;
                newAudioSource.spatialBlend = audioSource.spatialBlend;
                newAudioSource.loop = false;

                // Play sound and destroy the object after it finishes
                newAudioSource.Play();
                Destroy(audioHolder, newAudioSource.clip.length);

                // Destroy the original GameObject
              
            }
        }
    }

}
