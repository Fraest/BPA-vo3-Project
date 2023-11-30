using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RayCastScript : MonoBehaviour
{
    Camera cam;
    [SerializeField] float rayLength;
    private GameObject goal;

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
                //if a unit is clicked, select it
                if (hit.collider.CompareTag("Unit")){
                    hit.collider.gameObject.GetComponent<PlayerMovement>().selected = true;
                }
                else if (hit.collider.CompareTag("Level")){
                    //if level is clicked on, set goal to the point clicked
                    goal.transform.position = hit.point;

                    //moves all selected units
                    GameObject[] moveUnits = GameObject.FindGameObjectsWithTag("Unit");
                    foreach(GameObject unit in moveUnits){
                        if(unit.GetComponent<PlayerMovement>().selected){
                            unit.GetComponent<NavMeshAgent>().destination = goal.transform.position;
                        }
                    }
                }

                
            }
        }

        if (Input.GetMouseButtonDown(1)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit, rayLength)){
                //if player right clicks on unit, unit is deselected
                //if player right clicks on anything else, everything is deselected
                if(hit.collider.CompareTag("Unit")){
                    hit.collider.gameObject.GetComponent<PlayerMovement>().selected = false;
                }
                else{
                    GameObject[] deselectUnits = GameObject.FindGameObjectsWithTag("Unit");
                    foreach(GameObject unit in deselectUnits){
                        unit.gameObject.GetComponent<PlayerMovement>().selected = false;
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(2)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayLength)){
                if (hit.collider.CompareTag("Unit")){
                    hit.collider.GetComponent<NavMeshAgent>().destination = hit.collider.transform.position;
                }
                else{
                    GameObject[] stopUnits = GameObject.FindGameObjectsWithTag("Unit");
                    foreach(GameObject unit in stopUnits){
                        unit.gameObject.GetComponent<NavMeshAgent>().destination = unit.transform.position;
                    }
                }
            }
        }
    }
}
