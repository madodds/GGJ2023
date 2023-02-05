using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Globals;

public class SelectPlayerButton : MonoBehaviour
{
    public PlayerCharacter character;

    public CharacterSelect manager;
    public Button selfButton;

    public void SelectCharacter()
    {
        manager.ChooseType(character);
        selfButton.interactable = false;
    }
}
