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
        // Placeholder text if no winner is dectected.
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
        // It's possible we need to destroy the objects to reset them instead of just setting to null. Potential Bug.
        CharacterSelect.player1 = null;
        CharacterSelect.player2 = null;
        SceneManager.LoadScene(menuSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("The user has quit the game!");
        Application.Quit();
    }
}
