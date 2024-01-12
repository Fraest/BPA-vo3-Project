using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreDecision : MonoBehaviour
{
    public bool isCopper;
    void Awake() {
        //randomly decides if the ore is copper or iron
        if(Random.Range(0,2) == 0){
            isCopper = false;
            
        }
        else{isCopper = true;}
        Debug.Log(isCopper);
    }
}
