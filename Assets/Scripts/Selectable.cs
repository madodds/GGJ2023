using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public Color validHighlightColor = Color.green;
    public Color invalidHighlightColor = Color.red;
    Color defaultColor;

    MeshRenderer myRenderer;

    PlantNode plantNode;

    AudioSource audioSource;

    void Awake()
    {
        plantNode = GetComponent<PlantNode>();
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
        if(IsValid()){
            myRenderer.material.color = validHighlightColor;
        } else {
            myRenderer.material.color = invalidHighlightColor;
        }
    }

    void OnMouseExit()
    {
        myRenderer.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        Debug.Log("You clicked", this);
        if(plantNode){
            Debug.Log("Has PlantNode");
        }
        if(audioSource){
            audioSource.Play();
        }
    }

    bool IsValid(){
        return true;
    }
}
