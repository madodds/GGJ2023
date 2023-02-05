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
    public Dictionary<(PlayerCharacter, PlantResources), Material> materials;
    public Material dirtMaterial;
    public Dictionary<(int, int), GameObject> hexDictionary;
    //public GameObject originalhexObject;
    public int qLength = 9;
    public int rLength = 5;
    public float hexSize = 1.5f;
    
    public bool showTest = false;

    public PlantResources? purchasedPlant;

    public (int, int) p1Start = (0,2);

    public (int, int) p2Start = (8,2);

    void Awake()
    {
        hexes = this;
        dirtMaterial = Resources.Load<Material>($"Materials/Dirt");
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

                // Initialize starting plants
                if((i,j) == p1Start){
                    hexTile.owner = turnManager.player1.PlayerCharacter;
                    hexObject.AddComponent<Grass>().Sprout();
                    hexObject.AddComponent<Tree>().Sprout();
                }
                if((i, j) == p2Start){
                    hexTile.owner = turnManager.player2.PlayerCharacter;
                    hexObject.AddComponent<Grass>().Sprout();
                    hexObject.AddComponent<Tree>().Sprout();
                }
            }
        }
    }

    public bool CanPlacePlant(HexCoord hexCoord)
    {
        if(purchasedPlant != null){
            GameObject hexObject = hexDictionary[(hexCoord.q, hexCoord.r)];
            HexTile hexTile = hexObject.GetComponent<HexTile>();
            if(!hexTile){
                Debug.Log("no hextile");
                return false;
            }
            switch(purchasedPlant){
                case PlantResources.grass:
                case PlantResources.weeds:
                    return !hexTile.HasPlant();
                case PlantResources.flowers:
                case PlantResources.tumbleweeds:
                case PlantResources.carrots:
                case PlantResources.venus:
                    return hexTile.owner == turnManager.activePlayer.PlayerCharacter && hexTile.HasGrass();
                default: return false;
            }
        }
        return false;
    }

    public void PlacePlant(HexCoord hexCoord)
    {
        GameObject hexObject = hexDictionary[(hexCoord.q, hexCoord.r)];
        HexTile hexTile = hexObject.GetComponent<HexTile>();
        if(purchasedPlant == null) { return; }
        hexTile.owner = turnManager.activePlayer.PlayerCharacter;
        switch(purchasedPlant) {
            case PlantResources.grass:
                hexObject.AddComponent<Grass>().Sprout();
                break;
            case PlantResources.weeds:
                hexObject.AddComponent<Grass>().Sprout();
                hexObject.AddComponent<Weed>().Sprout();
                break;
            case PlantResources.flowers:
                hexObject.AddComponent<Flower>().Sprout();
                break;
            case PlantResources.carrots:
                hexObject.AddComponent<Carrot>().Sprout();
                break;
            case PlantResources.venus:
                hexObject.AddComponent<VenusFlyTrap>().Sprout();
                break;
            case PlantResources.tumbleweeds:
                hexObject.AddComponent<Tumbleweed>().Sprout();
                break;
            default:
                Debug.Log("invalid plant place");
                hexTile.owner  = null;
                break;
        }
        turnManager.turnPhase = TurnPhases.SpendResources;
        turnManager.RefreshUI();
    }
}
