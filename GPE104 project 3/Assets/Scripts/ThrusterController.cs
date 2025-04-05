using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.VirtualTexturing;

public class ThrusterController : MonoBehaviour
{
    public ParticleSystem thruster; // this is a public reference in the inspector where you will drag in the particle system component 
    public Rigidbody shipRigidbody; // public reference where you will drag in the ships rigid body componeent
  
    [Header("Thruster Settings")]
    public float minEmission = 10f;
    public float maxEmission = 20f;
    public float maxSpeed = 20f;

    private ParticleSystem.EmissionModule emission;

     void Start()
    {
        emission = thruster.emission; // with this line you basically saying : You're saying: “Hey Unity, grab the emission settings of this thruster particle system and store it in my emission variable so I can mess with it later.”
    }

     void Update()
    {
        float speed = shipRigidbody.velocity.magnitude; // Get the current speed of the spaceship by measuring the magnitude of its velocity vector

        float emissionRate = Mathf.Lerp(minEmission, maxEmission, speed / maxSpeed); // Calculates emission rate based on current speed (0 = minEmission, full speed = maxEmission)
       // now we mist apply that emmison rate 
       emission.rateOverTime = emissionRate; // this line is directly setting the rate at which particles are emitted in your ParticleSystem based on the emissionRate we calculated earlier.
    }




}
