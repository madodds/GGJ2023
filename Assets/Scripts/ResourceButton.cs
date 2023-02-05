using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Globals;

public class ResourceButton : MonoBehaviour
{
    public PlantResources plantType;
    public TextMeshProUGUI costText;
    public RawImage tileImage;
    public Button tileButton;
    public bool activated;

    public Action DeactivateAll;

    private int cost
    {
        get => ResourceCosts[plantType];
    }

    private void Start()
    {
        activated = false;
        costText.text = cost.ToString();
        tileButton.onClick.AddListener(BuyPlant);
    }

    public void SetCharacterTextures(PlayerObject character)
    { 
        tileButton.interactable = activated && (cost <= character.Money);
        tileImage.texture = LookupTextureAsset(character.PlayerCharacter, plantType);
    }

    public void BuyPlant(){
        DeactivateAll();
        turnManager.turnPhase = TurnPhases.PlacePlants;
        turnManager.activePlayer.TakeMoney(cost);
        hexes.purchasedPlant = plantType;
    }
}
