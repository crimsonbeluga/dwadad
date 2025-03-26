using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public GameObject healthBarPrefab; // The health bar prefab
    private GameObject healthBarInstance; // The instantiated health bar
    private Transform target; // The target to follow (your enemy or object)

    public float heightOffset = 1.5f; // How high above the target the health bar will appear

    void Start()
    {
        target = transform; // Set the target to this object's transform

        // Instantiate the health bar prefab at the object's position
        healthBarInstance = Instantiate(healthBarPrefab, target.position + new Vector3(0, heightOffset, 0), Quaternion.identity);

        // Make sure the health bar is a child of the Canvas
        healthBarInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);

        // Assign the HealthBarUI component so it updates properly
        HealthBarUI healthBarUI = healthBarInstance.GetComponent<HealthBarUI>();
        if (healthBarUI != null)
        {
            healthBarUI.SetTarget(target); // Set the target of the health bar to follow
        }
        else
        {
            Debug.LogError("⚠ HealthBarUI component missing in instantiated health bar prefab!");
        }

        // Make sure the health bar is active and visible
        healthBarInstance.SetActive(true);
    }

    void Update()
    {
        if (healthBarInstance && target)
        {
            // Get the world position of the object (target) plus the height offset
            Vector3 worldPosition = target.position + new Vector3(0, heightOffset, 0);

            // Convert world position to screen space to update the health bar's position
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

            // Check if the object is within the camera's view
            if (screenPosition.x >= 0 && screenPosition.x <= Screen.width && screenPosition.y >= 0 && screenPosition.y <= Screen.height)
            {
                healthBarInstance.transform.position = screenPosition;
            }
            else
            {
                Debug.LogWarning("Health bar target is out of camera view!");
            }
        }
    }

    void OnDestroy()
    {
        if (healthBarInstance != null)
        {
            // Add a delay to avoid flickering and make sure the health bar is destroyed after the object
            Destroy(healthBarInstance, 0.5f);
        }
    }
}
