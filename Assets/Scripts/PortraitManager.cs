using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Globals;

public class PortraitManager : MonoBehaviour
{
    public RawImage player1Portrait;
    public RawImage player2Portrait;
    // Start is called before the first frame update
    void Start()
    {
        player1Portrait.texture = LookupTextureAsset(CharacterSelect.player1.PlayerCharacter, MiscResources.portrait);
        player2Portrait.texture = LookupTextureAsset(CharacterSelect.player2.PlayerCharacter, MiscResources.portrait);
    }

}
