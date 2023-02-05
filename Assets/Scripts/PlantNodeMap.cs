using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlantNodeMap : MonoBehaviour
{
    public List<List<PlantNode>> nodelist;
    private float starttime;
    /*    public GameObject hex;
        public PlantNode plantNode;*/

    void InitializeNodes()
    {
        nodelist = new List<List<PlantNode>>();
        for (int x = -5; x < 5; x++)
        {
            List<PlantNode> templist = new List<PlantNode>();
            if (x == -5)
            {
                var plantNode = Resources.Load<PlantNode>("Prefab/PlantNode");
                PlantNode newPlantNode = Instantiate(plantNode);
                newPlantNode.SetCoordinates(x, 0);
                newPlantNode.SetState(Globals.states.tree, Globals.player.player1);
                templist.Add(newPlantNode);
            }
            else if (x == 4)
            {
                for (int y = -1; y < 3; y++)
                {
                    var plantNode = Resources.Load<PlantNode>("Prefab/PlantNode");
                    PlantNode newPlantNode = Instantiate(plantNode);
                    newPlantNode.SetCoordinates(x, y);
                    if (y == 0)
                    {
                        newPlantNode.SetState(Globals.states.tree, Globals.player.player2);
                    }
                    templist.Add(newPlantNode);
                }
            }
            else
            {
                for (int y = -2; y < 3; y++)
                {
                    var plantNode = Resources.Load<PlantNode>("Prefab/PlantNode");
                    PlantNode newPlantNode = Instantiate(plantNode);
                    newPlantNode.SetCoordinates(x, y);
                    newPlantNode.SetState(Globals.states.empty, Globals.player.none);
                    templist.Add(newPlantNode);
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
                List<(int, int)> neighbors = node.FindNeighbors();
                foreach ((int, int) neighbor in neighbors)
                {
                    PlantNode neighborNode = nodelist[neighbor.Item1][neighbor.Item2];
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
