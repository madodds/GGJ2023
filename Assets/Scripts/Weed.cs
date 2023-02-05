using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Globals;


public class Weed : MonoBehaviour
{

    public PlantResources plantType = PlantResources.weeds;

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
                // Debug.Log("Found material" + plantMaterial.name);
                // Transform billboardTransform = transform.Find("Billboard");
                // if(billboardTransform == null){
                //     Debug.Log("didn't find tile transform");
                // }
                // MeshRenderer tileRenderer = billboardTransform.gameObject.GetComponent<MeshRenderer>();
                // if(tileRenderer == null){
                //     Debug.Log("didn't find tile renderer");
                // }
                // foreach ( Material mat in tileRenderer.materials){
                //     Debug.Log(mat.name);
                // }
                // Material[] materials = tileRenderer.materials;
                // materials[1] = plantMaterial;
                // tileRenderer.materials = materials;
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
