using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Globals;

public class PortraitManager : MonoBehaviour
{
    public TurnManager turnManager;
    public List<RawImage> portraits;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var portrait in portraits)
        {
            portrait.texture = LookupTextureAsset(turnManager.CurrentCharacter.PlayerCharacter, MiscResources.portrait);
        }
    }

}
