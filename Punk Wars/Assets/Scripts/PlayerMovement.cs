using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform goal;
    public bool selected;
    [SerializeField] GameObject camera;

    private void Start() {
        selected = false;
    }
    private void Update()
    {
<<<<<<< Updated upstream
        //Comment stuff out for readability please 
        if (Input.GetMouseButtonDown(0))
        {
            Invoke("movePlayer", 0.1f);
=======
        if (Input.GetMouseButtonDown(1)){
            selected = false;
        }

        if (selected){
            //if raycast hits level, move player
            //probably a better way to do this but eh
            if (camera.GetComponent<RayCastScript>().mouseHit.collider.CompareTag("Level")){
                Invoke("movePlayer", 0.1f);
            }
>>>>>>> Stashed changes
        }
    }

    private void movePlayer(){
        agent.destination = goal.position;
    }
}
