using UnityEngine;

public class enterToStart : MonoBehaviour
{
    private GameManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            {
            manager.playGamePlayScene();
        }
    }
}
