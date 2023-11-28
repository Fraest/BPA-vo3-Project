using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    private GameObject goal;
    public bool selected;

    private void Start() {
        selected = false;
    }
    
    void Awake() {
        goal = GameObject.FindWithTag("Goal");
    }

    private void Update()
    {
        // if(Input.GetMouseButtonDown(1)){
        //     selected = false;
        // }
        
        //Comment stuff out for readability please 
        if (Input.GetMouseButtonDown(0))
        {
            if(selected){
                Invoke("movePlayer", 0.1f);
            }
        }
    }

    private void movePlayer(){
        agent.destination = goal.transform.position;
    }
}

