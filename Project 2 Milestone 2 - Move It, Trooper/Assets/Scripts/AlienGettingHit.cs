using UnityEngine;
using UnityEngine.Audio; // Make sure to import the Audio namespace for using AudioMixers

public class AlienGettingHit : MonoBehaviour
{
    public AudioClip hitSound;  // The sound to play when hit
    [Range(0f, 1f)] public float volume = 1f; // Volume control from 0 (silent) to 1 (full volume)

    public AudioMixer audioMixer;  // Reference to the AudioMixer
    public string volumeParameterName = "Volume";  // Name of the exposed parameter in the AudioMixer

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            // Play the hit sound at the position of the object
            if (hitSound != null)
            {
                AudioSource tempAudioSource = new GameObject("TempAudioSource").AddComponent<AudioSource>();
                tempAudioSource.clip = hitSound;

                // Set the volume by modifying the AudioMixer exposed parameter
                if (audioMixer != null)
                {
                    // Multiply volume by 4 and ensure the volume is clamped to the range of the parameter (-80dB to 0dB)
                    float adjustedVolume = Mathf.Clamp(volume * 4f, 0f, 1f);  // Scale the volume 4x
                    audioMixer.SetFloat(volumeParameterName, Mathf.Lerp(-80f, 0f, adjustedVolume));  // Map to dB scale
                }

                tempAudioSource.spatialBlend = 1.0f; // Optional: Set to 3D sound if needed
                tempAudioSource.Play();

                // Destroy the temporary AudioSource object after the clip finishes playing
                Destroy(tempAudioSource.gameObject, hitSound.length);
            }
        }
    }
}
