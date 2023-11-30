using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    public bool selected;
    [SerializeField] Behaviour halo;

    private void Start() {
        selected = false;
    }
    private void Update()
    {
        if(selected) {halo.enabled = true;}
        else {halo.enabled = false;}
    }
}

