using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCoord : MonoBehaviour
{
    public int q;
    public int r;
    public GameObject storeObj;

    public void Start(){
        PositionToHexCoords();
    }

    public void PositionToHexCoords(){
        if(storeObj){
            HexStore store = storeObj.GetComponent<HexStore>();
            float size = store.hexSize;
            float x = size * (Mathf.Sqrt(3) * q  +  Mathf.Sqrt(3)/2 * r); //q * 1.0f;
            float y = size * (                         3.0f/2 * r);//r * 1.0f;
            transform.position = new Vector3(x, 0, y);
        }
    }
}
