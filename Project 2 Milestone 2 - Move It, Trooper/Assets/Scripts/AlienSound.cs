using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class AlienSound : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public int damageAmount = 1;  // Amount of damage dealt
    public bool instantKill = false;  // If true, kills any object on collision

    private AudioSource audioSource;

    public AudioMixerGroup audioMixerGroup;



    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {




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
    // function to play audio wit audio mixer support

    private void PlayAudioWithMixer(AudioClip clip, Vector3 position, float volume, AudioMixerGroup mixerGroup)

    {
        GameObject audioObject = new GameObject("TempAudio");

        AudioSource tempAudioSource = audioObject.AddComponent<AudioSource>();

        // assign the clip and the setting s

        tempAudioSource.clip = clip;
        tempAudioSource.volume = volume;
        tempAudioSource.outputAudioMixerGroup = mixerGroup;
        tempAudioSource.Play();

        // destroy audio object after it has finished playing 

        Destroy(audioObject, clip.length);



    }


}
