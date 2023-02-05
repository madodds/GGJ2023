using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kill()
    {
        HexTile hexTile = GetComponent<HexTile>();
        if(hexTile != null){
            hexTile.RemoveBillboard();
            Grass grass = GetComponent<Grass>();
            if(grass){
                grass.Kill();
            }
            Damageable damageable = GetComponent<Damageable>();
            if(damageable!= null){
                Destroy(damageable);
            }
            Destroy(this);
        }
    }
}
