using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    public GameObject billboardPrefab;  // References to prototypical prefabs in
    public GameObject tilePrefab;       //  case we need to instantiate these
    public GameObject billboard; // "3D" representation of plant
    public GameObject tile; // Hexagonal base tile

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBillboard(Material billboardMaterial)
    {
        GameObject billboardObject;
        Transform billboardTransform = transform.Find("Billboard");
        if(billboardTransform){
            billboardObject = billboardTransform.gameObject;
        } else {
            billboardObject = Instantiate(billboardPrefab, transform);
        }
        MeshRenderer bbRenderer = billboardObject.GetComponent<MeshRenderer>();
        if(bbRenderer){
            bbRenderer.material = billboardMaterial;
        }
    }
}
