using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class OreBehavior : MonoBehaviour
{
    [SerializeField] GameObject regularOre, brokenOre;
    public int currentHealth;

    void Awake() {
        currentHealth = gameObject.GetComponent<HealthManager>().health;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //continuously updates the current health
        currentHealth = gameObject.GetComponent<HealthManager>().health;
        if(currentHealth <= 0) {destroyed(0,0);}
        //prevents health from going down if the ore is destroyed
        if(!regularOre.activeSelf){gameObject.GetComponent<HealthManager>().health = gameObject.GetComponent<HealthManager>().maxHealth;}
    }


    public void destroyed(int copper, int iron){
        //gives a random amount of an ore
        // if(regularOre.gameObject.GetComponent<OreDecision>().isCopper){copper += Random.Range(1,4);}
        // else{iron += Random.Range(1,4);}
        //deactivates the regular ore and activates the broken ore
        brokenOre.SetActive(true);
        //resets health for when it regens
        regularOre.SetActive(false);
    }
}
