using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlantNodeMap : MonoBehaviour
{
    public PlantNode[][] node_map_array;


    void InitializeNodes()
    {
        PlantNode plantnode = new PlantNode();
        node_map_array[0][0] = null;
        node_map_array[1][0] = null;
        node_map_array[2][0] = plantnode;
        node_map_array[2][0].SetState(Globals.states.tree, Globals.player.player1);
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
