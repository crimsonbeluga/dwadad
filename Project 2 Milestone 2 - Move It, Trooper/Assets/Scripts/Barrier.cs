using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Get the current position
        Vector3 position = transform.position;

        // Clamp the Y position to a maximum of 5
        if (position.y > 5)
        {
            position.y = 5;
            transform.position = position;
        }
    }
}
