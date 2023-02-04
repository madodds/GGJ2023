using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexStore : MonoBehaviour
{
    public Mesh tileMesh;
    Dictionary<(int, int), GameObject> hexDictionary;
    public GameObject originalHexTile;
    public int qLength = 5;
    public int rLength = 5;
    public int hexSize = 1;
    // Start is called before the first frame update
    void Start()
    {
        generate();
    }

    void generate()
    {
        hexDictionary = new Dictionary<(int, int), GameObject>();
        for(int i = 0; i < qLength; i++){
            for(int j = 0; j < rLength; j++){
                GameObject hexTile = Instantiate(originalHexTile);
                hexTile.name = "Tile " + i + ", " + j;
                HexCoord hexCoord = hexTile.GetComponent<HexCoord>();
                hexCoord.store = this;
                hexCoord.q = i;
                hexCoord.r = j;
                hexCoord.positionToHexCoords();
                hexDictionary.Add((hexCoord.q,hexCoord.r), hexTile);
            }
        }
    }
}
