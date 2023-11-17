using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform goal;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Invoke("movePlayer", 0.1f);
        }
    }

    private void movePlayer(){
        agent.destination = goal.position;
    }
}
