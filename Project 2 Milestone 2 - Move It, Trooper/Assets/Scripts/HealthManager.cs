using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float maxHealth = 100f;      // Max health of the object
    public float damageAmount = 10f;    // Amount of damage taken per collision

    public float currentHealth;        // Current health of the object
    private Image healthImage;          // Reference to the UI Image for health

    public GameObject healthImagePrefab; // Reference to the health image prefab
    private Canvas canvas;              // Reference to the Canvas in the scene

    private GameObject healthImageObj;  // Store instantiated health image object

    void Start()
    {
        currentHealth = maxHealth;

        // Try to find the Canvas in the scene at runtime
        canvas = FindObjectOfType<Canvas>();

        // Check if Canvas exists in the scene
        if (canvas == null)
        {
            Debug.LogError("No Canvas found in the scene. Please add a Canvas.");
            return;
        }

        // Spawn the health image above the object
        if (healthImagePrefab != null)
        {
            // Instantiate the image at the object's position + a bit of height
            healthImageObj = Instantiate(healthImagePrefab, transform.position + Vector3.up, Quaternion.identity);

            // Set the image's parent to the Canvas
            healthImageObj.transform.SetParent(canvas.transform, false);

            healthImage = healthImageObj.GetComponent<Image>();

            if (healthImage != null)
            {
                UpdateHealthBar();
            }

            Canvas.ForceUpdateCanvases();
        }
    }

    void Update()
    {
        if (healthImageObj != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up);
            healthImageObj.transform.position = screenPos;
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)healthImageObj.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Debug.Log("2D Trigger detected with " + other.gameObject.name);

            currentHealth -= damageAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            Debug.Log("Current Health after collision: " + currentHealth);

            UpdateHealthBar();

            if (currentHealth <= 0f)
            {
                if (gameObject.CompareTag("Player"))
                {
                    // Prevent GameOver if the Victory scene is already loaded
                    if (SceneManager.GetActiveScene().name != "VictoryScene") // Ensure you're not in the victory scene
                    {
                       
                    }
                }

                Debug.Log("Object destroyed because health reached 0.");
                Destroy(gameObject);
            }

        }
    }

    private void UpdateHealthBar()
    {
        if (healthImage != null)
        {
            float fillAmount = currentHealth / maxHealth;
            healthImage.fillAmount = Mathf.Clamp01(fillAmount);
            Debug.Log("Current Health: " + currentHealth);
            Debug.Log("Health Image Fill Amount: " + healthImage.fillAmount);
            Canvas.ForceUpdateCanvases();
        }
    }

    private void OnDestroy()
    {
        if (healthImageObj != null)
        {
            Destroy(healthImageObj); // Ensure health image is destroyed when this object is gone
        }
    }
}
