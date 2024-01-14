using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class OreBehavior : MonoBehaviour
{
    [SerializeField] GameObject regularOre, brokenOre;
    HealthManager hm;


    void Awake() {
        hm = gameObject.GetComponent<HealthManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(hm.health <= 0) {
            //!!!update later with copper and iron counters instead of 0
            if(regularOre.gameObject.GetComponent<OreDecision>().isCopper){
                destroyed(0);
            }
            else{
                destroyed(0);
            }
        }
        //prevents health from going down if the ore is destroyed
        if(!regularOre.activeSelf){hm.health = hm.maxHealth;}
    }


    public int destroyed(int ore){
        //deactivates the regular ore and activates the broken ore
        brokenOre.SetActive(true);
        //resets health for when it regens
        regularOre.SetActive(false);
        //adds 1 to 3 to an ore counter
        return (ore += Random.Range(1,4));
    }
}
