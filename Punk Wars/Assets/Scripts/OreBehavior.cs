using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class OreBehavior : MonoBehaviour
{
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
        currentHealth = gameObject.GetComponent<HealthManager>().health;
        if(currentHealth <= 0) {destroyed(0);}
    }


    public void destroyed(int ores){
        //gives a random amount of ores
        ores += Random.Range(1,3);
        Destroy(gameObject);
    }
}
