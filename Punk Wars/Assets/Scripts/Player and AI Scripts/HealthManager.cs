using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth, health;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(health>maxHealth) {health = maxHealth;}
        if(health<0) {health = 0;}
    }


    public void loseHealth(int damage){
        health -= damage;
    }
    

    public void gainHealth(int healing){
        health += healing;
    }
}
