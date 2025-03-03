using UnityEngine;

public class Meteor : MonoBehaviour
{
    private float speed; // The speed of the meteor's movement

    // Set the speed of the meteor's movement
    public void SetSpeed(float meteorSpeed)
    {
        speed = meteorSpeed;
    }

    private void Update()
    {
        // Move the meteor downward on the Y axis
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Check if the meteor's Y position is less than -5, if so, destroy it
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
}
