using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color validHighlightColor = Color.green;
    public Color invalidHighlightColor = Color.red;
    Color defaultColor;

    MeshRenderer renderer;

    PlantNode plantNode;

    AudioSource audioSource;

    void Awake()
    {
        plantNode = GetComponent<PlantNode>();
    }

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        defaultColor = renderer.material.color;
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseOver()
    {
        if(IsValid()){
            renderer.material.color = validHighlightColor;
        } else {
            renderer.material.color = invalidHighlightColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Show();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
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
        if(audioSource){
            audioSource.Play();
        }
    }

    bool IsValid(){
        return true;
    }
}
