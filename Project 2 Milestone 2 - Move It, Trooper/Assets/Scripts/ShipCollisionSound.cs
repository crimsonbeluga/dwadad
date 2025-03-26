using UnityEngine;

public class ShipCollisionSound : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        if (audioSource.clip != null)

        {
            audioSource.Play();
        }
        else
        {
            Debug.Log("no audio clip assigned in isnpector");
        }
    }
}
