using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Globals;

public class Grass : MonoBehaviour
{
    public Material groundMaterial;
    public PlantResources plantType = PlantResources.grass;

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
                Debug.Log("Found material" + plantMaterial.name);
                Transform tileTransform = transform.Find("Tile");
                if(tileTransform == null){
                    Debug.Log("didn't find tile transform");
                }
                MeshRenderer tileRenderer = tileTransform.gameObject.GetComponent<MeshRenderer>();
                if(tileRenderer == null){
                    Debug.Log("didn't find tile renderer");
                }
                foreach ( Material mat in tileRenderer.materials){
                    Debug.Log(mat.name);
                }
                Material[] materials = tileRenderer.materials;
                materials[1] = plantMaterial;
                tileRenderer.materials = materials;
                //tileRenderer.materials[1] = plantMaterial;
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
            hexTile.owner = null;
            Transform tileTransform = transform.Find("Tile");
            MeshRenderer tileRenderer = tileTransform.gameObject.GetComponent<MeshRenderer>();
            Material[] materials = tileRenderer.materials;
            materials[1] = hexes.dirtMaterial;
            tileRenderer.materials = materials;
            Destroy(this);
        }
    }
}
