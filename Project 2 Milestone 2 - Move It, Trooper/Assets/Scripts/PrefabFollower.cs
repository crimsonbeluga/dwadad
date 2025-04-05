using UnityEngine;

public class FollowAbove : MonoBehaviour
{
    public Transform target;            // The target object (the object to follow)
    public Vector3 offset = new Vector3(0, 2f, 0); // Offset to position the health bar above the target object

    private RectTransform rectTransform;  // Reference to the RectTransform of the health bar (assuming it's a UI element)

    void Start()
    {
        // Ensure the health bar has a RectTransform, which it should if it's a UI element
        rectTransform = GetComponent<RectTransform>();

        if (rectTransform == null)
        {
            Debug.LogError("FollowAbove script requires a RectTransform on the object.");
        }
    }

    void Update()
    {
        if (target != null && rectTransform != null)
        {
            // Convert the target's world position to screen space
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(target.position + offset);

            // Update the health bar's position on the screen
            rectTransform.position = screenPosition;
        }
    }
}
