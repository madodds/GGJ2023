using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public Color validHighlightColor = Color.green;
    public Color invalidHighlightColor = Color.red;
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
        if(IsValid()){
            renderer.material.color = validHighlightColor;
        } else {
            renderer.material.color = invalidHighlightColor;
        }
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

    bool IsValid(){
        return true;
    }
}
