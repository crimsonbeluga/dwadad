using UnityEngine;

public class DestroyUfO : MonoBehaviour
{
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            Destroy(gameObject); // Destroy this object
        }
    }

}

