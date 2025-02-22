using UnityEngine;

public class Pawn : MonoBehaviour
{
    [Header("damage")]
   

    [Header("Teleportation Settings")]
     public KeyCode TeleportLeft;
     public KeyCode TeleportRight;
     public KeyCode TeleportUp;
     public KeyCode TeleportDown;
     public KeyCode RandomTeleport;

    [Header("Teleportation Bounds")]
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float teleportDistance = 1200f; // Adjustable teleport distance
    




   
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialization if needed
    }

    // Update is called once per frame
    void Update()
    {


        Transform tf = transform;

        // Teleportation controls
        if (Input.GetKeyDown(TeleportLeft))
            tf.position += tf.TransformDirection(Vector3.left) * teleportDistance;

        if (Input.GetKeyDown(TeleportRight))
            tf.position += tf.TransformDirection(Vector3.right) * teleportDistance;

        if (Input.GetKeyDown(TeleportUp))
            tf.position += tf.TransformDirection(Vector3.up) * teleportDistance;

        if (Input.GetKeyDown(TeleportDown))
            tf.position += tf.TransformDirection(Vector3.down) * teleportDistance;
    }



    

    // This method will handle random teleportation
    public void TeleportRandomly()
    {
        Transform tf = transform;
        // Teleport to a random position within specified bounds
        Vector3 position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
        tf.SetPositionAndRotation(position, Quaternion.identity); // Set the new position and reset rotation
    }
}
