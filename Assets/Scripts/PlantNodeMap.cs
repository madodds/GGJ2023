using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlantNodeMap : MonoBehaviour
{
    public List<List<PlantNode>> nodelist;
    private float starttime;
    public GameObject hex;

    void InitializeNodes()
    {
        nodelist= new List<List<PlantNode>>();
        for(int x=0; x < 10; x++){
            List<PlantNode> templist = new List<PlantNode>();
            if(x==0){
                PlantNode plantnode = new PlantNode();
                plantnode.SetCoordinates(x,2);
                plantnode.SetState(Globals.states.tree, Globals.player.player1);
                GameObject newhex = Instantiate(hex, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                plantnode.Initialize(newhex);
                templist.Add(plantnode);
            }else if(x==9){
                for(int y=1 ; y<5 ; y++){
                    PlantNode plantnode = new PlantNode();
                    plantnode.SetCoordinates(x,y);
                    if(y==2){
                        plantnode.SetState(Globals.states.tree, Globals.player.player2);
                    }
                    GameObject newhex = Instantiate(hex, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                    plantnode.Initialize(newhex);
                    templist.Add(plantnode);
                } 
            }else{
                for(int y=0; y < 10; y++){
                    PlantNode plantnode = new PlantNode();
                    plantnode.SetCoordinates(x,y);
                    plantnode.SetState(Globals.states.empty, Globals.player.none);
                    GameObject newhex = Instantiate(hex, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                    plantnode.Initialize(newhex);
                    templist.Add(plantnode);
                }
            }

            nodelist.Add(templist);
        }
    }


    void CheckNeighbors()
    {
        foreach (List<PlantNode> templist in nodelist)
        {
            foreach (PlantNode node in templist)
            {
                Globals.player nodePlayer = node.GetPlayer();
                Globals.states nodeState = node.GetStates();
                if (nodeState == Globals.states.empty)
                {
                    node.SetCheckedState(true);
                    continue;
                }
                List<int[]> neighbors = node.ReturnNeighbor();
                foreach (int[] neighbor in neighbors)
                {
                    PlantNode neighborNode = nodelist[neighbor[0]][neighbor[1]];
                    if (!neighborNode.GetCheckedState())
                    {
                        continue;
                    }
                    Globals.player neighborNodePlayer = neighborNode.GetPlayer();
                    Globals.states neighborNodeState = neighborNode.GetStates();
                    if (neighborNodeState == Globals.states.empty)
                    {
                        neighborNode.SetCheckedState(true);
                        continue;
                    }
                    if (neighborNodePlayer == nodePlayer)
                    {
                        continue;
                    }
                    else
                    {
                        // Deal or take damage
                    }
                }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        this.starttime = Time.time;
        InitializeNodes();
        
    }

    // Update is called once per frame
    void Update()
    {
        //CheckNeighbors();
    }

    
}
