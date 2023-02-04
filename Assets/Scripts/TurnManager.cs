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
    public int player = 0;   // current player.
    public int[] resources = {0, 0};

    public int secondsDelayBetweenPhases = 5;

    // Start is called before the first frame update
    void Start()
    {
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
                    Debug.Log( GetPlayerName() + " spends 1 resource.");
                    resources[player] -= 1;
                    Debug.Log( GetPlayerName() + " has " + resources[player] + " resources.");
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
        Debug.Log( GetPlayerName() + " gains " + addedResources + " resources.");
        resources[player] += addedResources;
        Debug.Log( GetPlayerName() + " has " + resources[player] + " resources.");
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
        Debug.Log("Starting Turn for " + GetPlayerName());
        turnPhase = TurnPhases.StartTurn;
    }

    void EndTurn() {
        if(player==0){
            player = 1;
        } else {
            player = 0;
        }
        GoToPhase("doStartTurn");
    }

    string GetPlayerName(){
        string playerName;
         if(player==0){
            playerName = "Player 1";
        } else {
            playerName = "Player 2";
        }
        return playerName;
    }
}
