using System;
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
    public bool selected, atGoal, inHitRange = false;
    GameObject enemy;
    float timer = 0, timer2 = 0;


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

        //if in range to damage something, do so once per second
        timer += Time.deltaTime;
        // timer2 += Time.deltaTime;
        // Debug.Log(timer2);
        // if(timer2 >= .2){
        //     timer2 = .2f;
        // }
        if(timer >= 1){
            if(inHitRange){
                damage();
                //creates burst of particles on hit for .2 seconds
                // oreParicles.emissionRate = 100;
                // if(timer2 >= .2){
                //     oreParicles.emissionRate = 0;
                //     timer2 = 0;
                // }
            }
            timer = 0;
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


    void OnTriggerEnter(Collider other) {
        //if unit is in the collider of an ore/enemy, set a bool to true
        //if said bool is true, unit attacks the object it's colliding with repeatedly in the update function
        //ore colliders are much bigger than the model suggests for this to work
        if(other.gameObject.CompareTag("Ore")){
            enemy = other.gameObject;
            inHitRange = true;
        }
    }


    void OnTriggerExit(Collider other) {
        //sets unit to not attacking the object it was attacking
        if(other.gameObject.CompareTag("Ore")){
            enemy = null;
            inHitRange = false;
        }
    }


    public void damage(){
        //throws a ton of errors once the ore gets destroyed
        //this just prevents error clutter
        try{
            enemy.GetComponent<HealthManager>().loseHealth(1);
        }catch(Exception e){}
    }


    public void wait(){
        //does nothing, used to just delay something using invoke
    }
}

