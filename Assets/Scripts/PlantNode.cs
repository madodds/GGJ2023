using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantNode : MonoBehaviour
{
    public Globals.states state;
    private int timer;
    private int[] connected;
    private Globals.player player;

    public void SetState(Globals.states state, Globals.player player){
        state = state;
        player = player;
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
}
