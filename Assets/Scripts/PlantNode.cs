using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlantNode : MonoBehaviour
{
    private Globals.states state;
    private int timer;
    private int[] connected;
    private Globals.player player;
    private int coordinatex;
    private int coordinatey;
    private bool checkedState = false;

    public void SetState(Globals.states state, Globals.player player){
        this.state = state;
        this.player = player;
    }

    //public void Initialize(GameObject hex)
    //{

    ////    function axial_to_oddr(hex):
    ////var col = hex.q + (hex.r - (hex.r & 1)) / 2
    ////var row = hex.r
    ////return OffsetCoord(col, row)
    //    this.hex = hex;
    //    Renderer renderer = hex.GetComponent<Renderer>();
    //    Vector3 size = renderer.bounds.size;
    //    float x = (size.x)*(coordinatex);
    //    float y = (size.y)*(coordinatey);
    //    float col = x + (y - (coordinatex & 1)) / 2;
    //    float row = y;
        
    //    Vector3 position = new Vector3((float)(col), (float)(row), (float)0.0);
        
    //    Quaternion rotate = new Quaternion(0, 0, 0, 0);
    //    renderer.transform.position = (position);
    //    renderer.transform.rotation = rotate;
    //    Vector3 rot = renderer.transform.rotation.eulerAngles;
    //    rot = new Vector3(rot.x, rot.y + 180, rot.z);
    //    renderer.transform.rotation = Quaternion.Euler(rot);
    //    /*hex.AddComponent<TextMesh>();
    //    hex.GetComponent<TextMesh>().text = $"{position.x}, {position.y}";*/

    //}
    public void SetCoordinates(int coordx, int coordy){
        this.coordinatex = coordx;
        this.coordinatey = coordy;
        Renderer renderer = this.GetComponent<Renderer>();
        Vector3 size = renderer.bounds.size;
        float x = (size.x) * (coordinatex);
        float y = (size.y) * (coordinatey);
        float col = x + (y - (coordinatex & 1)) / 2;
        float row = y;

        Vector3 position = new Vector3((float)(col), (float)(row), (float)0.0);

        Quaternion rotate = new Quaternion(0, 0, 0, 0);
        renderer.transform.position = (position);
        renderer.transform.rotation = rotate;
        Vector3 rot = renderer.transform.rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y + 180, rot.z);
        renderer.transform.rotation = Quaternion.Euler(rot);
    }
    public void SetCheckedState(bool check)
    {
        this.checkedState = check;
    }

    // Start is called before the first frame update
    public void DebugPosition()
    {
        Vector3 position = this.transform.position;
        Debug.Log($"{position.x}, {position.y}");
        Debug.Log($"{coordinatex}, {coordinatey}");
    }
    void Start()
    {
        state = Globals.states.empty;
        player = Globals.player.none;
        /*hexPrefab = Resources.Load<GameObject>("Assets/Prefab/hex.prefab");
        hex = Instantiate(hexPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));*/


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            DebugPosition();
        }
        this.SetCheckedState(false);
    }

    public Globals.player GetPlayer() { return player; }
    public Globals.states GetStates() { return state; }
    public bool GetCheckedState() { return checkedState; }
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
