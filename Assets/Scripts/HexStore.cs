using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class HexStore : MonoBehaviour
{
    //public Mesh tileMesh;
    public GameObject tilePrefab;
    public GameObject billboardPrefab;
    Dictionary<(PlayerCharacter, PlantResources), Material> materials;
    Dictionary<(int, int), GameObject> hexDictionary;
    //public GameObject originalhexObject;
    public int qLength = 9;
    public int rLength = 5;
    public int hexSize = 1;
    
    public bool showTest = false;

    void Awake()
    {
        materials = new Dictionary<(PlayerCharacter, PlantResources), Material>();
        Array characterValues = Enum.GetValues(typeof(PlayerCharacter));
        foreach( PlayerCharacter cv in characterValues )
        {
            Array plantValues = Enum.GetValues(typeof(PlantResources));
            foreach( PlantResources pv in plantValues)
            {
                Material material = Resources.Load<Material>(
                    $"Materials/PlayerTypes/{Enum.GetName(typeof(PlayerCharacter), cv)}/{Enum.GetName(typeof(PlantResources), pv)}"
                );
                if(!material){
                    Debug.Log("Error loading material ");
                }
                else{
                    materials.Add((cv, pv), material);
                }
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void Generate()
    {
        hexDictionary = new Dictionary<(int, int), GameObject>();
        // Delete this when testing is over
        // <---
            Array characterValues = Enum.GetValues(typeof(PlayerCharacter));
            //Debug.Log("characterValues " + characterValues);
            Array plantValues = Enum.GetValues(typeof(PlantResources));
        // --->
        for(int i = 0; i < qLength; i++){
            for(int j = 0; j < rLength; j++){
                int s = i+j;
                if(s<2 || s>10){
                    continue;
                }
                GameObject hexObject = Instantiate(tilePrefab);
                hexObject.name = "Hex " + i + ", " + j;
                HexTile hexTile = hexObject.AddComponent(typeof(HexTile)) as HexTile;
                hexTile.billboardPrefab = billboardPrefab;
                hexTile.tilePrefab = tilePrefab;

                if(showTest && i < plantValues.Length && j < characterValues.Length)
                {
                    Material billboardMaterial = materials[((PlayerCharacter)j, (PlantResources)i)];
                    if(!billboardMaterial){
                        //Debug.Log("Couldn't find material for "+ Enum.GetName(typeof(PlayerCharacter), characterValues.GetValue(j)) + " " + Enum.GetName(typeof(PlantResources), plantValues.GetValue(i)));
                    } else{
                        hexTile.SetBillboard(billboardMaterial);
                    }
                }

                HexCoord hexCoord = hexObject.GetComponent<HexCoord>();
                hexCoord.storeObj = gameObject;
                hexCoord.q = i;
                hexCoord.r = j;
                //hexCoord.PositionToHexCoords();
                hexDictionary.Add((hexCoord.q,hexCoord.r), hexObject);
            }
        }
    }
}
