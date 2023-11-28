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
    [SerializeField] Behaviour halo;

    private void Start() {
        selected = false;
    }
    
    void Awake() {
        goal = GameObject.FindWithTag("Goal");
    }

    private void Update()
    {
        if(selected) {halo.enabled = true;}
        else {halo.enabled = false;}
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

