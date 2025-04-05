using UnityEngine;
using UnityEngine.UI;

public class obstacle3 : MonoBehaviour
{
    public float maxHealth = 100f;    // Max health of the object
    public float damageAmount = 10f;  // Amount of damage taken per collision

    private float currentHealth;      // Current health of the object
    private Slider healthSlider;      // Reference to the UI slider that will follow the object

    public GameObject sliderPrefab;   // Reference to the health slider prefab
    public Canvas canvas;             // Reference to the Canvas in the scene

    void Start()
    {
        currentHealth = maxHealth;

        // Ensure a valid canvas is provided
        if (canvas == null)
        {
            Debug.LogError("Canvas is not assigned in the HealthManager!");
            return;
        }

        // Spawn the health slider above the object
        if (sliderPrefab != null)
        {
            // Instantiate the slider at the object's position + a bit of height
            GameObject sliderObj = Instantiate(sliderPrefab, transform.position + Vector3.up, Quaternion.identity);

            // Set the slider's parent to the Canvas
            sliderObj.transform.SetParent(canvas.transform, false);  // False keeps the local scale/rotation unchanged

            healthSlider = sliderObj.GetComponent<Slider>();

            // Set the slider's max value to the max health
            if (healthSlider != null)
            {
                healthSlider.maxValue = maxHealth;
                healthSlider.value = currentHealth; // Set the initial value to current health
            }
        }
    }

    void Update()
    {
        // Update the slider's position to follow the object (hover just above it)
        if (healthSlider != null)
        {
            // Convert the object's position to screen space and update the slider's position
            healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up);
        }
    }

    // This method is called when the object collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Reduce health by the damage amount
        currentHealth -= damageAmount;

        // Ensure health doesn't go below 0
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // Update the health slider value
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        // Destroy the object and its slider if health reaches 0
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);  // Destroy the object
            Destroy(healthSlider.gameObject);  // Destroy the slider
        }
    }
}
