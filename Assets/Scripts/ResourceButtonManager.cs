using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceButtonManager : MonoBehaviour
{
    public TurnManager turnManager;
    public List<ResourceButton> resourceButtons;

    // Start is called before the first frame update
    void Start()
    {
        RefreshButtonTextures();
    }

    public void RefreshButtonTextures()
    {
        foreach (var button in resourceButtons)
        {
            button.SetCharacterTextures(turnManager.CurrentCharacter);
        }
    }
}
