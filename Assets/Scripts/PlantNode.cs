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
        state = state;
        player = player;
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
        return List<int>[coordinatex, coordinatey];
    }

    private int[] AxialDirection(){

    }

    private int[] NodeAdd(int[] hex, int x, int y){
        newx = hex[0] + x;
        newy = hex[1] + y;
        int[] newhex = {newx, newy};
        return newhex; 
    }

    public int[] ReturnNeighbor(){
        int[] neighbors;
        foreach(int[] hex in Globals.hex()){
            int count = 0;
            int[] newhex = AxialAdd(hex, coordinatex, coordinatey);
            switch(newhex){
                case (newhex[0] < 0) || (newhex[1] < 0):
                    break;
                case newhex[0] > 9:
                    break;
                case newhex[1] > 4:
                    break;
                case newhex[0] == 9 && (newhex[1] < 0 || newhex[1] > 3):
                    break;
                case newhex[0] == 0 && newhex[1] != 2:
                    break;
                default:
                    neighbors[count] = hex;
                    break;
            }
            count++;
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
