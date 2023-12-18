using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class UnitControls : MonoBehaviour
{
    Camera cam;
    [SerializeField] float rayLength;
    private GameObject goal, baseMenu;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
    void Awake() {
        goal = GameObject.FindWithTag("Goal");
        baseMenu = GameObject.FindWithTag("BaseMenu");
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

        #region unit controls
        if (Input.GetMouseButtonDown(0)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, rayLength)){
                //if a unit is clicked, select it
                if (hit.collider.CompareTag("Unit")){
                    hit.collider.gameObject.GetComponent<UnitBehavior>().selected = true;
                    hit.collider.gameObject.GetComponent<UnitBehavior>().atGoal = false;
                }
                else if (hit.collider.CompareTag("Level")){
                    //if level is clicked on, set goal to the point clicked
                    goal.transform.position = hit.point;

                    //moves all selected units
                    GameObject[] moveUnits = GameObject.FindGameObjectsWithTag("Unit");
                    foreach(GameObject unit in moveUnits){
                        if(unit.GetComponent<UnitBehavior>().selected){
                            unit.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeAll;
                            unit.GetComponent<NavMeshAgent>().destination = goal.transform.position;
                            unit.GetComponent<UnitBehavior>().atGoal = false;
                        }
                    }
                }
                else if(hit.collider.CompareTag("Base")){
                    GameObject[] deselectUnits = GameObject.FindGameObjectsWithTag("Unit");
                    foreach(GameObject unit in deselectUnits){
                        unit.gameObject.GetComponent<UnitBehavior>().selected = false;
                    }
                    
                }

                
            }
        }

        if (Input.GetMouseButtonDown(1)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit, rayLength)){
                //if player right clicks on unit, unit is deselected
                //if player right clicks on anything else, all units are deselected
                if(hit.collider.CompareTag("Unit")){
                    hit.collider.gameObject.GetComponent<UnitBehavior>().selected = false;
                }
                else{
                    GameObject[] deselectUnits = GameObject.FindGameObjectsWithTag("Unit");
                    foreach(GameObject unit in deselectUnits){
                        unit.gameObject.GetComponent<UnitBehavior>().selected = false;
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(2)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayLength)){
                if (hit.collider.CompareTag("Unit")){
                    //if player middle clicks on unit, unit stops
                    hit.collider.GetComponent<NavMeshAgent>().destination = hit.collider.transform.position;
                    hit.collider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    hit.collider.GetComponent<UnitBehavior>().atGoal = true;
                }
                else{
                    GameObject[] stopUnits = GameObject.FindGameObjectsWithTag("Unit");
                    foreach(GameObject unit in stopUnits){
                        //if player middle clicks on anything else, all units stop
                        unit.gameObject.GetComponent<NavMeshAgent>().destination = unit.transform.position;
                        unit.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        unit.gameObject.GetComponent<UnitBehavior>().atGoal = true;
                    }
                }
            }
        }
        #endregion
    }
}
