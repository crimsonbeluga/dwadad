using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemyhealthbar : MonoBehaviour
{
    public Image healthBar;
    private Transform target; // The enemy this health bar follows
    private Vector3 offset = new Vector3(0, 2, 0); // Adjust the height
    private Camera mainCamera;

    public void Initialize(Transform enemyTransform)
    {
        target = enemyTransform;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (target != null)
        {
            // Follow the enemy
            transform.position = target.position + offset;

            // Face the camera
            transform.LookAt(transform.position + mainCamera.transform.forward);
        }
    }

    public void UpdateHealthBar(float healthPercentage)
    {
        healthBar.fillAmount = healthPercentage;
    }
}