using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using static Globals;

public class TurnManager : MonoBehaviour
{

    public TurnPhases turnPhase = TurnPhases.BetweenPhases;
    public PlayerObject CurrentCharacter => activePlayer;
    public ResourceButtonManager resourceButtonManager;

    public TextMeshProUGUI player1Mana;
    public TextMeshProUGUI player2Mana;
    public PlayerObject activePlayer;

    public PlayerObject player1;
    public PlayerObject player2;

    public int secondsDelayBetweenPhases = 5;

    // Start is called before the first frame update
    void Start()
    {
        if(CharacterSelect.player1){
            player1 = CharacterSelect.player1;
        }
        else
        {
            player1 = new PlayerObject();
            player1.PlayerName = "Player 1";
            player1.PlayerCharacter = PlayerCharacter.Necromancer;
        }
        if(CharacterSelect.player2){
            player2 = CharacterSelect.player2;
        }
        else 
        {
            player2 = new PlayerObject();
            player2.PlayerName = "Player 2";
            player2.PlayerCharacter = PlayerCharacter.PumpkinKing;
        }

        turnManager = this;

        activePlayer = player1;
        GoToPhase("doStartTurn");
    }

    // Update is called once per frame
    void Update()
    {
        switch(turnPhase){
            case TurnPhases.BetweenPhases:
                break;
            case TurnPhases.StartTurn: 
                GoToPhase("doGainResources");
                break;
            case TurnPhases.GainResources:
                // perform resource calcs here
                GoToPhase("doResolvePlants");
                break;
            case TurnPhases.ResolvePlants:
                // call to TileManager to resolve plants
                
                break;
            case TurnPhases.ResolveRabbits:
                // call to TileManager to resove rabbits
                GoToPhase("doSpendResources");
                break;
            case TurnPhases.SpendResources:
                // Activate purchasing UI then
                // Await clicking end turn
                if(Input.GetKeyDown(KeyCode.Return)){
                    EndTurn();
                }
                break;
            default:
                break;
        }
    }

    void GoToPhase(string doNext)
    {
        turnPhase = TurnPhases.BetweenPhases;
        //Debug.Log("Next Phase: " + doNext);
        Invoke(doNext, secondsDelayBetweenPhases);
    }

    void doGainResources()
    {
        int addedResources = 2;
        Debug.Log(activePlayer.PlayerName + " gains " + addedResources + " resources.");
        activePlayer.AddMoney(addedResources);
        Debug.Log(activePlayer.PlayerName + " has " + activePlayer.Money + " resources.");
        RefreshUI();
        turnPhase = TurnPhases.GainResources;
    }

    void doResolvePlants()
    {
        Debug.Log("Resolving Plants");
        turnPhase = TurnPhases.ResolvePlants;
        foreach(KeyValuePair<(int, int), GameObject> kvp in hexes.hexDictionary){
            GameObject hexObject = kvp.Value;
            HexTile hexTile = hexObject.GetComponent<HexTile>();
            if(hexTile.owner != null && (PlayerCharacter)hexTile.owner == turnManager.activePlayer.PlayerCharacter){
                VenusFlyTrap ven = hexObject.GetComponent<VenusFlyTrap>();
                Tumbleweed tum = hexObject.GetComponent<Tumbleweed>();
                if(ven){
                    ven.Attack();
                }
                if(tum){
                    tum.Attack();
                }
            }
        }
        GoToPhase("doResolveRabbits");
    }

    void doResolveRabbits()
    {
        Debug.Log("Resolving Rabbits");
        turnPhase = TurnPhases.ResolveRabbits;
    }

    void doCheckEndGame()
    {
        Debug.Log("Check for end of game");
        turnPhase = TurnPhases.CheckEndGame;
    }

    void doSpendResources()
    {
        Debug.Log("Spend Resources");
        turnPhase = TurnPhases.SpendResources;
        RefreshUI();
    }

    void doStartTurn()
    {
        RefreshUI();
        Debug.Log("Starting Turn for " + activePlayer.PlayerName);
        turnPhase = TurnPhases.StartTurn;
    }

    void EndTurn() {
        // Maybe bug? who knows.
        // activePlayer = activePlayer == player1 ? player2 : player1;
        if(activePlayer.PlayerCharacter==player1.PlayerCharacter){
            activePlayer = player2;
        }
        else {
            activePlayer = player1;
        }
        GoToPhase("doStartTurn");
    }

    public void RefreshUI()
    {
        resourceButtonManager.RefreshButtonTextures();
        player1Mana.text = player1.Money.ToString();
        player2Mana.text = player2.Money.ToString();
    }

}
