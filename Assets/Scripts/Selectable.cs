using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Globals;

public class Selectable : MonoBehaviour
{
    public Color validHighlightColor = Color.green;
    public Color invalidHighlightColor = Color.red;
    Color defaultColor;

    MeshRenderer myRenderer;
    AudioSource audioSource;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        defaultColor = myRenderer.material.color;
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseOver()
    {
        HexTile hexTile = GetComponentInParent<HexTile>();
        HexCoord hexCoord = GetComponentInParent<HexCoord>();
        if(hexTile && hexCoord) {
            if( hexes.purchasedPlant != null ){
                if(hexes.CanPlacePlant(hexCoord)){
                    myRenderer.material.color = validHighlightColor;
                } else {
                    myRenderer.material.color = invalidHighlightColor;
                }
            } 
        }
    }

    void OnMouseExit()
    {
        myRenderer.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        HexTile hexTile = GetComponentInParent<HexTile>();
        HexCoord hexCoord = GetComponentInParent<HexCoord>();
        if(hexTile && hexCoord) {
            if( hexes.purchasedPlant != null ){
                // Attempt to place plant in this tile
                if(hexes.CanPlacePlant(hexCoord)){
                    Debug.Log("Placing " + Enum.GetName(typeof(PlantResources), hexes.purchasedPlant));
                    hexes.PlacePlant(hexCoord);
                    hexes.purchasedPlant = null;
                }
                else {
                    Debug.Log("Invalid location for " + Enum.GetName(typeof(PlantResources), hexes.purchasedPlant));
                }
            }
        }
        if(audioSource){
            audioSource.Play();
        }
    }
}
