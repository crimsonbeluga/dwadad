using UnityEngine;

public class PresEnterToStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
           GameManager.instance.ActivateTitleScreen();

            Debug.Log("enter was pressed");
        }
    }
}
