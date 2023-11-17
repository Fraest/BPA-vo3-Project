using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    Camera cam;
    public LayerMask navMask;
    [SerializeField] float rayLength;
    [SerializeField] Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
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

            if(Physics.Raycast(ray, out hit, rayLength, navMask)){
                goal.position = hit.point;
            }
        }
    }
}
