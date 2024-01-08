using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class UnitBehavior : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Behaviour halo;
    public bool selected, atGoal;

    private void Start() {
        selected = false;
    }
    private void Update()
    {
        //signals if unit is selected
        if(selected) {halo.enabled = true;}
        else {halo.enabled = false;}

        //checks if unit is within vicinity of goal
        //it looks bad i know shut up
        if ((transform.position.x-1 <= agent.destination.x) && (agent.destination.x <= transform.position.x +1) && (transform.position.y-1 <= agent.destination.y) && (agent.destination.y <= transform.position.y +1)){
            atGoal = true;
        }
    }

    private void OnCollisionEnter(Collision other) {
        //stops unit if its going to the same place and is at the goal
        //yes this also looks bad, see previous comment
        if(other.gameObject.GetComponent<UnitBehavior>().atGoal && other.gameObject.GetComponent<NavMeshAgent>().destination != agent.destination){
            agent.destination = transform.position;
            atGoal = true;
        }

        //if unit collides with a unit that isnt going to the same place it just goes through to avoid annoyances
        if(other.gameObject.GetComponent<NavMeshAgent>().destination != agent.destination){
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Invoke("wait", 2.0f);
            other.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }


    public void wait(){
        //does nothing, used to just delay something using invoke
    }
}

