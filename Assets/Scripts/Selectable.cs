using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public Color highlightColor = Color.white;
    Color defaultColor;

    MeshRenderer renderer;

    PlantNode plantNode;

    void Awake()
    {
        plantNode = GetComponent<PlantNode>();
    }

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        defaultColor = renderer.material.color;
    }

    void OnMouseOver()
    {
        renderer.material.color = highlightColor;
    }

    void OnMouseExit()
    {
        renderer.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        Debug.Log("You clicked", this);
        if(plantNode){
            Debug.Log("Has PlantNode");
        }
    }
}
