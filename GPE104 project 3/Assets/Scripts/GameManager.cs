using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playEnterToStartScene()
    {
        SceneManager.LoadScene("PressEnterToStartScene");
    }

    public void playMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void playGamePlayScene()
    {
        SceneManager.LoadScene("GamePlayScene");
    }

    public void quitToDesktop()
    {
        Application.Quit();
    }

}