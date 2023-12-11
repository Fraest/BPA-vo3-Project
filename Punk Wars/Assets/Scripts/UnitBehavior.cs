using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class UnitBehavior : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Behaviour halo;
    public bool selected, atGoal, stopped;

    private void Start() {
        selected = false;
    }
    private void Update()
    {
        if(selected) {halo.enabled = true;}
        else {halo.enabled = false;}
        if ((this.transform.position.x-1 <= agent.destination.x) && (agent.destination.x <= this.transform.position.x +1) && (this.transform.position.y-1 <= agent.destination.y) && (agent.destination.y <= this.transform.position.y +1)){
            atGoal = true;
        }
    }

    private void OnCollisionEnter(Collision other) {
       if(other.gameObject.GetComponent<UnitBehavior>().atGoal){
            agent.destination = this.transform.position;
            atGoal = true;
       }
    }
}

