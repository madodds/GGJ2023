using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{

    public int hp = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("Tooke "+damage+" damage. At "+hp+" HP");
        if(hp <= 0){
            Weed weed = GetComponent<Weed>();
            if(weed){
                weed.Kill();
            }
            Tumbleweed tumbleweed = GetComponent<Tumbleweed>();
            if(tumbleweed){
                tumbleweed.Kill();
            }
            VenusFlyTrap ven = GetComponent<VenusFlyTrap>();
            if(ven){
                ven.Kill();
            }
            Flower flower = GetComponent<Flower>();
            if(flower){
                flower.Kill();
            }
            Carrot carrot = GetComponent<Carrot>();
            if(carrot){
                carrot.Kill();
            }
            Tree tree = GetComponent<Tree>();
            if(tree){
                tree.Kill();
            }
        }
    }
}
