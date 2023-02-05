using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Globals;


public class Flower : MonoBehaviour
{

    public PlantResources plantType = PlantResources.flowers;

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
                damageable.hp = 1;
            }
            else{
                Debug.Log("Can't sprout. No owner");    
            }
        }
        else {
            Debug.Log("No tile.");
        }
    }
}
