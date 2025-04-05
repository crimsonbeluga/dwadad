using UnityEngine;

public class Motheralien : MonoBehaviour
{
    public float AlienMotherspeed = 1f;
    public GameObject player;
    private Rigidbody2D rb; // Reference to Rigidbody2D
    private Vector2 previousPosition; // Track last position for rotation

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D component
        if (player == null)
            player = GameObject.FindWithTag("Player");

        previousPosition = rb.position; // Initialize previous position
        FacePlayer(); // Rotate towards player at start
    }

    void FixedUpdate() // Use FixedUpdate for physics-based movement
    {
        if (player == null) return; // Prevent errors if player is missing

        // Move towards the player using Rigidbody2D
        Vector2 newPosition = Vector2.MoveTowards(rb.position, player.transform.position, AlienMotherspeed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition); // Physics-based movement

        // Calculate movement direction
        Vector2 movementDirection = newPosition - previousPosition;

        if (movementDirection != Vector2.zero)
        {
            // Calculate angle based on movement direction
            float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90; // Offset for correct facing direction
        }

        previousPosition = newPosition; // Update previous position
    }

    void FacePlayer()
    {
        Vector2 directionToPlayer = player.transform.position - transform.position;
        float initialAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        rb.rotation = initialAngle - 90; // Apply initial rotation
    }
}
