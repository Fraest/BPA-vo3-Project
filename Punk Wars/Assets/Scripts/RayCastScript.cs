using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    Camera cam;
    [SerializeField] float rayLength;
    public GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
    void Awake() {
        goal = GameObject.FindWithTag("Goal");
    }

    // Update is called once per frame
    void Update()
    {
        //draw ray
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = rayLength;
        //convert to world point
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if (Input.GetMouseButtonDown(0)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, rayLength)){
                //if a player character is clicked, select it
                //if level is clicked on, set goal to the point clicked
                if (hit.collider.CompareTag("Player")){
                    hit.collider.gameObject.GetComponent<PlayerMovement>().selected = true;
                    Debug.Log("selected");
                }
                if (hit.collider.CompareTag("Level")){
                    goal.transform.position = hit.point;
                    Debug.Log("move");
                }
            }
        }
    }
}
