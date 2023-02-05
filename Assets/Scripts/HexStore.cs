using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HexStore : MonoBehaviour
{
    Dictionary<(int, int), PlantNode> hexDictionary;
    private PlantNode originalHexTile;
    public int hexSize = 1;
    List<(int, int)> litUpNeighbors;
    // Start is called before the first frame update
    void Start()
    {
        generate();
    }

    void generate()
    {
        hexDictionary = new Dictionary<(int, int), PlantNode>();
        for(int i = 0; i < Globals.qLength; i++){
            for(int j = 0; j < Globals.rLength; j++){
                originalHexTile = Resources.Load<PlantNode>("Prefab/PlantNode");
                PlantNode hexTile = Instantiate(originalHexTile);
                hexTile.AddComponent<HexCoord>();
                hexTile.name = "Tile " + i + ", " + j;
                HexCoord hexCoord = hexTile.GetComponent<HexCoord>();
                hexCoord.store = this;
                hexCoord.q = i;
                hexCoord.r = j;
                hexCoord.positionToHexCoords();
                hexTile.SetCoordinates(i, j);
                if(i == 0 && j == 0)
                {
                    hexTile.SetState(Globals.states.tree, Globals.player.player1);
                }
                if(i == Globals.qLength-1 && j == Globals.rLength - 1)
                {
                    hexTile.SetState(Globals.states.tree, Globals.player.player2);
                }
                hexDictionary.Add((hexCoord.q,hexCoord.r), hexTile);
            }
        }
    }

    private void Update()
    {
        bool neighborsLit = false;
        foreach(PlantNode hexTile in hexDictionary.Values)
        {
            if (hexTile.GetLightUpNeighborFlag())
            {
                List<(int, int)> neighbors = hexTile.GetNeighbors();
                litUpNeighbors = new List<(int, int)>();
                foreach ((int, int) neighbor in neighbors)
                {
                    hexDictionary[(neighbor)].setLightFlag(true);
                    litUpNeighbors.Add((neighbor));
                    

                }
                neighborsLit = true;
            }
        }
        if (!neighborsLit && (litUpNeighbors != null && litUpNeighbors.Count > 0))
        {
            foreach((int, int) neighbor in litUpNeighbors)
            {
                hexDictionary[neighbor].setLightFlag(false);
            }
        }
    }
}
