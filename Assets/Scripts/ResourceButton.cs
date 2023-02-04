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

    private int cost;
    private void Start()
    {
        cost = ResourceCosts[plantType];
        costText.text = cost.ToString();
    }

    public void SetCharacterTextures(PlayerObject character)
    { 
        tileButton.enabled = character.Money < cost;
    }

    
    public static RawImage GetPlayerPlantResources(PlayerCharacter playerCharacter, PlantResources plantResource)
    {

    }
}
