using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Globals;


public class VenusFlyTrap : MonoBehaviour
{

    public PlantResources plantType = PlantResources.venus;

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
        Debug.Log("Sprouting...");
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
                damageable.hp = 2;
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

    public void Attack()
    {
        HexCoord hexCoord = GetComponent<HexCoord>();
        foreach((int, int) direction in hexDirections){
            (int q, int r) = direction;
            (int, int) checkCoords = (q+hexCoord.q, r+hexCoord.r);
            if(hexes.hexDictionary.ContainsKey(checkCoords)){
                GameObject otherHexObj = hexes.hexDictionary[checkCoords];
                if(otherHexObj){
                    HexTile otherHexTile = otherHexObj.GetComponent<HexTile>();
                    if(otherHexTile.owner!=null){
                        PlayerCharacter otherOwner = (PlayerCharacter) otherHexTile.owner;
                        if(otherHexTile.owner != null && otherOwner != turnManager.activePlayer.PlayerCharacter){
                            Debug.Log("VenutFlyTrap Attacks!");
                            Damageable damageable = otherHexObj.GetComponent<Damageable>();
                            if(damageable){
                                damageable.TakeDamage(1);
                            }
                            else{
                                Grass grass = otherHexObj.GetComponent<Grass>();
                                if(grass){
                                    grass.Kill();
                                }
                            }
                        }   
                    }
                }
            }
        }
    }
}
