using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantNodeGrid : MonoBehaviour
{
    public int width = 10;
    public int height = 4;


    // Start is called before the first frame update
    void Start()
    {
        var plantNode = Resources.Load<PlantNode>("Prefab/PlantNode");
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                Instantiate(plantNode, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
