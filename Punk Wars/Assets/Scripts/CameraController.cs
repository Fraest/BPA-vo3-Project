using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehavior
{
    public float moveSpeed;
    public float moveTime;

    public Vector3 newPos;

    //Called before the first frame update
    void Start()
    {
        //stops the transform from equaling zero
        newPos = transform.position;
    }

    //Update is called once per frame
    void Update()
    {
        HandleMoveInput();
    }

    void HandleMoveInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPos += (transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPos += (transform.forward * -moveSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPos += (transform.right * -moveSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPos += (transform.right * moveSpeed);
        }

        //makes the panning smooth
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * moveTime);
    }
}