using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlantNode : MonoBehaviour
{
    private Globals.states state = Globals.states.empty;
    private Globals.player player = Globals.player.none;
    private int coordinatex;
    private int coordinatey;
    private bool checkedState = false;
    public Color validHighlightColor = Color.green;
    public Color invalidHighlightColor = Color.red;
    Color defaultColor;
    private bool lightFlag = false;
    private bool neighborLightFlag = false;
    private List<(int, int)> neighbors;

    public void SetState(Globals.states state, Globals.player player){
        this.state = state;
        this.player = player;
    }
    public void SetCoordinates(int coordx, int coordy){
        coordinatex = coordx;
        coordinatey = coordy;
        neighbors = FindNeighbors();
        
    }
    public void SetCheckedState(bool check)
    {
        this.checkedState = check;
    }

    // Start is called before the first frame update
    public void DebugPosition()
    {
        /*Debug.Log($"{state}");*/
        Debug.Log($"Node {coordinatex}, {coordinatey} neighbors:");
        Debug.Log("#####################");
        foreach ((int, int) arr in neighbors)
        {
            Debug.Log($"{arr.Item1}, {arr.Item2}");
        }
        Debug.Log("#####################");
    }
    void Start()
    {
        defaultColor = GetComponent<Renderer>().material.color;


    }

    // Update is called once per frame
    void Update()
    {
        this.SetCheckedState(false);
        if (lightFlag) {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            GetComponent<Renderer>().material.color = defaultColor;
        }
    }

    public Globals.player GetPlayer() { return player; }
    public Globals.states GetStates() { return state; }
    public bool GetCheckedState() { return checkedState; }

    public void SetDestroy()
    {
        Destroy(this);
    }
    public List<int> GetCoordinates(){
        List<int> coordinates = new List<int>
        {
            coordinatex,
            coordinatey
        };
        return coordinates;
    }


    private (int, int) NodeAdd(int[] hex, int x, int y){
        int newx = hex[0] + x;
        int newy = hex[1] + y;
        (int, int) newhex = (newx, newy);
        return newhex; 
    }

    public List<(int, int)> FindNeighbors(){
        List<(int, int)> neighbors = new List<(int, int)>();
        foreach(int[] hex in Globals.hex()){
            (int, int) newhex = NodeAdd(hex, coordinatex, coordinatey);
            
            if ((newhex.Item1 < 0) || (newhex.Item2 < 0)){
                continue;
            }
            if (newhex.Item1 >= Globals.qLength) {
                continue;
            }
            if (newhex.Item2 >= Globals.rLength) { 
                continue; 
            }
            neighbors.Add(newhex);
        }
        return neighbors;
    }
    public List<(int, int)> GetNeighbors()
    {
        return neighbors;
    }

    private void OnMouseDown()
    {
        neighborLightFlag = true;
        DebugPosition();
    }

    void OnMouseOver()
    {
        if (IsValid())
        {
            GetComponent<Renderer>().material.color = validHighlightColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = invalidHighlightColor;
        }
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = defaultColor;
        Debug.Log($"{coordinatex}, {coordinatey}");
        neighborLightFlag= false;
    }

    bool IsValid()
    {
        return true;
    }


    public void setLightFlag(bool neighborLightFlag)
    {
        lightFlag = neighborLightFlag;
    }
    
    public bool GetLightUpNeighborFlag()
    {
        return neighborLightFlag;
    }
}
