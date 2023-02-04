using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string MainGameSceneName = "MainGame";
    public string HowToPlaySceneName = "HowToPlay";

    public void PlayGame()
    {
        SceneManager.LoadScene(MainGameSceneName);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(HowToPlaySceneName);
    }

    public void QuitGame()
    {
        Debug.Log("The user has quit the game!");
        Application.Quit();
    }
}
