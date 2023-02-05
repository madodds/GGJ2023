using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Globals;
using System;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{

    public TextMeshProUGUI announcementText;
    public Button dryadButton;
    public Button pumpkinButton;
    public Button necroButton;
    public float waitSeconds = 3;
    public string nextSceneName = "MainGame";

    public static PlayerObject player1;
    public static PlayerObject player2;

    private PlayerObject activePlayer;
    private bool loadNextScene = false;

    // Start is called before the first frame update
    void Start()
    {
        player1 = gameObject.AddComponent<PlayerObject>();
        player1.PlayerName = "Player 1";
        player1.AddMoney(1);
        player2 = gameObject.AddComponent<PlayerObject>();
        player2.PlayerName = "Player 2";
        player2.AddMoney(1);
        DontDestroyOnLoad(gameObject);
        PlayerPrompt(player1);
    }

    // Update is called once per frame
    void Update()
    {
        if (loadNextScene)
        {
            if (waitSeconds > 0)
            {
                waitSeconds -= Time.deltaTime;
            }
            else
            {
                loadNextScene = false;
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    private void PlayerPrompt(PlayerObject player)
    {
        activePlayer = player;
        announcementText.text = $"{activePlayer.PlayerName}, choose your character";
    }

    public void ChooseType(PlayerCharacter character)
    {
        if (!loadNextScene)
        {
            activePlayer.PlayerCharacter = character;
            activePlayer.PlayerName = Enum.GetName(typeof(PlayerCharacter), character);
            if (activePlayer == player1)
            {
                PlayerPrompt(player2);
            }
            else
            {
                announcementText.text = $"Starting Game: {player1.PlayerName} vs {player2.PlayerName}";
                loadNextScene = true;
            }
        }
    }

    public static PlayerObject GetWinnerChickenSandwich()
    {
        if (player1 != null && player1.WonTheGame)
        {
            return player1;
        }
        if (player2 != null && player2.WonTheGame)
        {
            return player2;
        }
        return null;
    }
}
