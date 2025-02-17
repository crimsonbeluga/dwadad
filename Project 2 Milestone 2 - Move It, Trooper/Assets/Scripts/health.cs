using UnityEngine;

public class health : Pawn
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damageAmount = 100;  // Amount of damage taken
    public int healingAmount = 20;

    void Start()
    {
        currentHealth = maxHealth;  // Initialize health at the start 
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            // Get the death component
            Death deathComponent = GetComponent<Death>();
            if (deathComponent != null)
            {
                // Call Die() method to handle death
                deathComponent.Die();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        // Get the death component and call Die
        Death deathComponent = GetComponent<Death>();
        if (deathComponent != null)
        {
            deathComponent.Die();
        }
        else
        {
            Debug.Log("Object does not have a Death component.");
            gameObject.SetActive(false); // Default behavior: disable the object
        }
    }
}
