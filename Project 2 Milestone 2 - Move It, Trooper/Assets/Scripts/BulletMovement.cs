using UnityEngine;

public class BulletMovement : Shooter
{
    public float bulletSpeed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * bulletSpeed * Time.deltaTime);
    }
}
