using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static Globals;

public class ResourceButtonManager : MonoBehaviour
{
    public TurnManager turnManager;
    public List<ResourceButton> resourceButtons;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var button in resourceButtons)
        {
            button.DeactivateAll = DeactivateAll;
        }
        RefreshButtonTextures();
    }

    public void RefreshButtonTextures()
    {
        foreach (var button in resourceButtons)
        {
            if(turnManager.turnPhase == TurnPhases.SpendResources){
                button.activated = true;
            }
            else {
                button.activated = false;
            }
            button.SetCharacterTextures(turnManager.CurrentCharacter);
        }
    }

    public void DeactivateAll()
    {
        foreach (var button in resourceButtons)
        {
            button.activated = false;
            button.tileButton.interactable = false;
        }
    }
}
