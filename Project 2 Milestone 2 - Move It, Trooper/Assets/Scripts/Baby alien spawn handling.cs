using Unity.VisualScripting;
using UnityEngine;

public class Babyalienspawnhandling : HealthManager
{
    public GameObject Babyalien;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void OnDestroy()
    {
        if (Babyalien != null)
        {
            Instantiate(Babyalien, transform.position, transform.rotation);

            float offset = 2f;

            Instantiate(Babyalien, transform.position + Vector3.left * offset, transform.rotation);

            Instantiate(Babyalien, transform.position + Vector3.right * offset, transform.rotation);
        }
        else
        {
            Debug.Log("prefab of baby alien is not assigned");
        }
    }
}