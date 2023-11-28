using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    Camera cam;
    [SerializeField] float rayLength;
    [SerializeField] Transform goal;
    public RaycastHit mouseHit;
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

            if(Physics.Raycast(ray, out mouseHit, rayLength)){
                //if level is clicked on, set goal to the point clicked
                if (mouseHit.collider.CompareTag("Level")){
                    goal.position = mouseHit.point;
                }
                if (mouseHit.collider.CompareTag("Player")){
                    mouseHit.collider.gameObject.GetComponent<PlayerMovement>().selected = true;
                }
            }
        }
    }
}
