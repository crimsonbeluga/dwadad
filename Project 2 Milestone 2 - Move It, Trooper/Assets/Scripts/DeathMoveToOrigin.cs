using UnityEngine;

public class DeathMoveToOrigin : Death
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Override the Death method to move the object instead of destroying it
    public  override void Die()
    {
        transform.position = Vector3.zero; // Moves the object to (0,0,0)
    }
}
