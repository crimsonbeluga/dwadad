using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image healthBarFill;
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(target.position + new Vector3(0, 0.75f, 0));
            transform.position = screenPosition;
        }
    }

    public void UpdateHealthBar(float healthPercentage)
    {
        Debug.Log("Health Bar Updated: " + healthPercentage); // ✅ Test if it's updating
        healthBarFill.fillAmount = healthPercentage;
    }
}
