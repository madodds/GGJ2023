using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum TurnPhases
    {
        BetweenPhases,
        StartTurn,
        GainResources,
        ResolvePlants,
        ResolveRabbits,
        CheckEndGame,
        SpendResources
    }

    public TurnPhases turnPhase = TurnPhases.BetweenPhases;
    public PlayerObject CurrentCharacter => activePlayer;
    public ResourceButtonManager resourceButtonManager;
    private PlayerObject activePlayer;

    public int secondsDelayBetweenPhases = 5;

    // Start is called before the first frame update
    void Start()
    {
        activePlayer = CharacterSelect.player1;
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
                GoToPhase("doResolveRabbits");
                break;
            case TurnPhases.ResolveRabbits:
                // call to TileManager to resove rabbits
                GoToPhase("doSpendResources");
                break;
            case TurnPhases.SpendResources:
                // Activate purchasing UI then
                // Await clicking end turn
                if (Input.GetMouseButtonDown(0)){
                    Debug.Log(activePlayer.PlayerName + " spends 1 resource.");
                    activePlayer.TakeMoney(1);
                    Debug.Log(activePlayer.PlayerName + " has " + activePlayer.Money + " resources.");
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
        turnPhase = TurnPhases.GainResources;
    }

    void doResolvePlants()
    {
        Debug.Log("Resolving Plants");
        turnPhase = TurnPhases.ResolvePlants;
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
    }

    void doStartTurn()
    {
        resourceButtonManager.RefreshButtonTextures();
        Debug.Log("Starting Turn for " + activePlayer.PlayerName);
        turnPhase = TurnPhases.StartTurn;
    }

    void EndTurn() {
        // Maybe bug? who knows.
        activePlayer = activePlayer == CharacterSelect.player1 ? CharacterSelect.player2 : CharacterSelect.player1;
        GoToPhase("doStartTurn");
    }

}
