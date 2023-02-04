using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlantNodeMap : MonoBehaviour
{
    public List<PlantNode> nodelist;


    void InitializeNodes()
    {

        for(int x=0; x < 10; x++){
            if(x==0){
                PlantNode plantnode = new PlantNode();
                plantnode.SetCoordinates(x,2);
                plantnode.SetState(Globals.states.tree, Globals.player.player1);
                nodelist.Add(plantnode);
            }else if(x==9){
                for(int y=1 ; y<5 ; y++){
                    PlantNode plantnode = new PlantNode();
                    plantnode.SetCoordinates(x,y);
                    if(y==2){
                        plantnode.SetState(Globals.states.tree, Globals.player.player2);
                    }
                    nodelist.Add(plantnode);
                } 
            }else{
                for(int y=0; y < 10; y++){
                    PlantNode plantnode = new PlantNode();
                    plantnode.SetCoordinates(x,y);
                    plantnode.SetState(Globals.states.empty, Globals.player.none);
                    nodelist.Add(plantnode);
                }
            }     

        }
    }
        

    // Start is called before the first frame update
    void Start()
    {
        
        InitializeNodes();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
