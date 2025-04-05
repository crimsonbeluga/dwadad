using UnityEngine;

public class Backgroundmusic : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Play the background music as soon as the scene starts
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    void Update()
    {
        // You can add other logic here if needed for updates
    }
}
