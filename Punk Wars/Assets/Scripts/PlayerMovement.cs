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
<<<<<<< Updated upstream
        if (Input.GetMouseButtonDown(0))
        {
            Invoke("movePlayer", 0.1f);

            if (Input.GetMouseButtonDown(1)) {
                selected = false;
            }

            if (selected) {
                //if raycast hits level, move player
                //probably a better way to do this but eh
                if (GetComponent<Camera>().GetComponent<RayCastScript>().mouseHit.collider.CompareTag("Level")) {
                    Invoke("movePlayer", 0.1f);
                }
=======
        if(Input.GetMouseButtonDown(1)){
            selected = false;
        }
        //Comment stuff out for readability please 
        if (Input.GetMouseButtonDown(0))
        {
            if(selected){
                Invoke("movePlayer", 0.1f);
>>>>>>> Stashed changes
            }
        }
    }

<<<<<<< Updated upstream
    private void movePlayer()
    {
        agent.destination = goal.position;
=======
    private void movePlayer(){
        agent.destination = goal.transform.position;
>>>>>>> Stashed changes
    }
}
