using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public Color HighlightColor = Color.white;
    Color DefaultColor;

    MeshRenderer Renderer;

    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
        DefaultColor = Renderer.material.color;
    }

    void OnMouseOver()
    {
        Renderer.material.color = HighlightColor;
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        Renderer.material.color = DefaultColor;
        Debug.Log("Mouse left GameObject.");
    }
}
