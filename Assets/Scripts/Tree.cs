using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using static Globals;

public class Tree : MonoBehaviour
{

    public PlantResources plantType = PlantResources.tree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sprout()
    {
        Debug.Log("Sprouting Tree...");
        HexTile hexTile = GetComponent<HexTile>();
        if(hexTile != null){
            if(hexTile.owner != null){
                PlayerCharacter pc = (PlayerCharacter)hexTile.owner;
                Material plantMaterial = hexes.materials[(pc, plantType)];
                if(plantMaterial == null){
                    Debug.Log("didn't find material");
                }

                hexTile.SetBillboard(plantMaterial);
                Damageable damageable = gameObject.AddComponent<Damageable>();
                damageable.hp = 3;
            }
            else{
                Debug.Log("Can't sprout. No owner");    
            }
        }
        else {
            Debug.Log("No tile.");
        }
    }

    public void Kill()
    {
        HexTile hexTile = GetComponent<HexTile>();
        if(hexTile != null){
            if(hexTile.owner==turnManager.player1.PlayerCharacter){
                CharacterSelect.player2.WonTheGame = true;
            } else if(hexTile.owner==turnManager.player2.PlayerCharacter){
                CharacterSelect.player1.WonTheGame = true;
            }
            SceneManager.LoadScene("EndGame");
            hexTile.RemoveBillboard();
            Grass grass = GetComponent<Grass>();
            if(grass){
                grass.Kill();
            }
            Damageable damageable = GetComponent<Damageable>();
            if(damageable!= null){
                Destroy(damageable);
            }
            Destroy(this);
        }
    }
}
