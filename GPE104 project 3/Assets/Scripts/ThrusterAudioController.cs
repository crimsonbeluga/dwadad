using Unity.VisualScripting;
using UnityEngine;

public class ThrusterAudioController : MonoBehaviour
{

    public AudioSource thrusterSound; //the audio source component you will select for the thruster sound
    public Rigidbody shipRigidbody; // reference to the rigid body of the space ship you wiull drag it in inside the inspector
    public float minSpeedThreshold = 0.1f; // this is the minimum speed that the ship must be going for the thruster sound to start playing 
    public float maxSpeed = 20f; // maximum speed of the space ship
    public float minVolume = 0.05f; // the minimum volume when the ship is at its lowest possible speed
    public float minPitch = 0.2f; // the lowest pitch the ship can be when the ship is at the lowest possible speed

    private bool isThrusterPlaying = false;  //The variable is being initialized with the value false, which means the thruster sound is not playing when the game begins or when the script first runs. Essentially, it's saying, "at the start, the sound is off."

    private void Update()
    {
        // get the current speed of the ship from the ships rigid body and transfer that value into data thats helt in our current speed float variabel

        float currentSpeed = shipRigidbody.velocity.magnitude;

        AdjustThrusterAudio(currentSpeed); //


    }

    void AdjustThrusterAudio(float currentSpeed)
    {
        // If the speed is greater than the threshold, adjust the volume and pitch
        if (currentSpeed > minSpeedThreshold)
        {
            // Adjust the volume based on speed (0 to 1 scale)
            float volume = Mathf.Lerp(minVolume, 1f, Mathf.Clamp01(currentSpeed / maxSpeed));
            thrusterSound.volume = volume;

            // Adjust the pitch based on speed (minPitch is the lowest pitch, 1.5f is the highest pitch)
            float pitch = Mathf.Lerp(minPitch, 1.5f, Mathf.Clamp01(currentSpeed / maxSpeed));
            thrusterSound.pitch = pitch;

            // Play the sound if it's not already playing
            if (!thrusterSound.isPlaying)
            {
                thrusterSound.Play();
                isThrusterPlaying = true;
            }
        }
        else
        {
            // When the speed is low but not zero, keep the sound playing with low volume and pitch
            float volume = Mathf.Lerp(minVolume, 1f, Mathf.Clamp01(currentSpeed / maxSpeed));
            thrusterSound.volume = volume;

            float pitch = Mathf.Lerp(minPitch, 1f, Mathf.Clamp01(currentSpeed / maxSpeed));
            thrusterSound.pitch = pitch;

            // Make sure the sound continues playing even at low speeds
            if (!thrusterSound.isPlaying)
            {
                thrusterSound.Play();
                isThrusterPlaying = true;
            }
        }
    }

}