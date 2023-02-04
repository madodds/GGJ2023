using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantNode : MonoBehaviour
{
    public Globals.states state;
    private int timer;
    private int[] connected;
    private Globals.player player;
    private int coordinatex;
    private int coordinatey;

    public void SetState(Globals.states state, Globals.player player){
        this.state = state;
        this.player = player;
    }

    public void SetCoordinates(int x, int y){
        coordinatex = x;
        coordinatey = y;
    }

    // Start is called before the first frame update
    void Start()
    {
        state = Globals.states.empty;
        player = Globals.player.none;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<int> GetCoordinates(){
        List<int> coordinates = new List<int>
        {
            coordinatex,
            coordinatey
        };
        return coordinates;
    }


    private int[] NodeAdd(int[] hex, int x, int y){
        int newx = hex[0] + x;
        int newy = hex[1] + y;
        int[] newhex = {newx, newy};
        return newhex; 
    }

    public List<int[]> ReturnNeighbor(){
        List<int[]> neighbors = new List<int[]>();
        foreach(int[] hex in Globals.hex()){
            int[] newhex = NodeAdd(hex, coordinatex, coordinatey);
            if ((newhex[0] < 0) || (newhex[1] < 0)){
                continue;
            }
            if (newhex[0] > 9) {
                continue;
            }
            if (newhex[1] > 4) { 
                continue; 
            }
            if((newhex[0] == 9) && (newhex[1] < 0 || newhex[1] > 3))
            {
                continue;
            }
            if(newhex[0] == 0 && newhex[1] != 2)
            {
                continue;
            }
            neighbors.Add(hex);
        }
        return neighbors;
    }

// function axial_direction(direction):
//     return axial_direction_vectors[direction]

// function axial_add(hex, vec):
//     return Hex(hex.q + vec.q, hex.r + vec.r)

// function axial_neighbor(hex, direction):
//     return axial_add(hex, axial_direction(direction))
}
