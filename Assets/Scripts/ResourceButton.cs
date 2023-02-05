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

    private int cost
    {
        get => ResourceCosts[plantType];
    }

    private void Start()
    {
        costText.text = cost.ToString();
    }

    public void SetCharacterTextures(PlayerObject character)
    { 
        tileButton.interactable = cost < character.Money;
        tileImage.texture = LookupTextureAsset(character.PlayerCharacter, plantType);
    }
}
