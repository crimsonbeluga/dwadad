using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionPress()

    {
        Debug.Log("options button clicked");
        GameManager.instance.ActivateOptionsScreen();
    }

}
