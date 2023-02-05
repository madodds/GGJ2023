using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Globals;

public class EndGameManager : MonoBehaviour
{
    public RawImage background;
    public TextMeshProUGUI announcementText;
    public string menuSceneName = "MainMenu";

    private void Start()
    {
        PlayerObject winner = CharacterSelect.GetWinnerChickenSandwich();
        string announcementTextString = "Game Over, baby.";
        if (winner != null)
        {
            announcementTextString = $"{winner.name} won the game!!!";
            background.texture = LookupTextureAsset(winner.PlayerCharacter, MiscResources.background);
        }
        announcementText.text = announcementTextString;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("The user has quit the game!");
        Application.Quit();
    }
}
