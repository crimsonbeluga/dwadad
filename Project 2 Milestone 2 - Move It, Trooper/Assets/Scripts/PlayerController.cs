using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Teleportation Settings")]
    public KeyCode RandomTeleport;  // Declare this at the class level

    // Reference to the Pawn script
    private Pawn pawnScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Pawn component attached to the same GameObject
        pawnScript = GetComponent<Pawn>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the random teleport key is pressed
        if (Input.GetKeyDown(RandomTeleport))
        {
            // Call the teleport function in the Pawn script
            pawnScript.TeleportRandomly(); // Call the new method directly
        }
    }
}
