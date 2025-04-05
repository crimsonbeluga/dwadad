using UnityEngine;
public class Bulletdamage : MonoBehaviour
{
    
    public int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        healthManager healthManagerScript = other.GetComponent<healthManager>();
        if (healthManagerScript != null)
        {
            healthManagerScript.takeDamage(damage);
        }
    }

}
