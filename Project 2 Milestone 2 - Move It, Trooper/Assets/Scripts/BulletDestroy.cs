using UnityEngine;

public class BulletDestroy : Shooter
{
    public AudioClip destroySound; // Assign the audio clip in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        // Make sure the audio source is set for 3D audio
        audioSource.spatialBlend = 1.0f; // 1.0 = 3D sound
        audioSource.minDistance = 1f; // The minimum distance to hear the sound
        audioSource.maxDistance = 50f; // The maximum distance the sound can be heard
    }

    // Called when the bullet collides with a trigger (meteor)
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (destroySound != null)
        {
            // Set the position of the sound relative to the bullet
            audioSource.transform.position = transform.position;

            // Play the sound (this will now be 3D)
            audioSource.PlayOneShot(destroySound);
        }

        // Destroy the object the bullet collided with
        Destroy(other.gameObject);

        // Destroy the bullet itself after impact
        Destroy(gameObject);
    }
}
