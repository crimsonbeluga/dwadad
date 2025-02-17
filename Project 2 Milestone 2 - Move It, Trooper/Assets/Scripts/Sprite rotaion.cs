using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    private Transform tf; // Create a variable for our transform component
    public float turnSpeed; // Create a variable for the degrees we rotate in one frame draw

    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>(); // Load our transform component into our variable
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}