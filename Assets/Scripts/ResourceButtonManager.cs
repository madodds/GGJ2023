using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceButtonManager : MonoBehaviour
{

    public List<ResourceButton> resourceButtons;
    // Start is called before the first frame update
    void Start()
    {

        var character = new PlayerObject()
        {
            PlayerCharacter = Globals.PlayerCharacter.Necromancer
        };
        character.AddMoney(2);
        foreach (var button in resourceButtons)
        {
            button.SetCharacterTextures(character);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
