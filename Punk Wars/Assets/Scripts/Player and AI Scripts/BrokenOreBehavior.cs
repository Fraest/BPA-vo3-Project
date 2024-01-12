using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenOreBehavior : MonoBehaviour
{
    [SerializeField] GameObject regularOre;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;        
    }


    // Update is called once per frame
    void Update()
    {
        //after two minutes, regens the ore
        timer += Time.deltaTime;
        if(timer >= 120){
            timer = 0;
            Debug.Log(regularOre.activeSelf);
            Debug.Log(gameObject.activeSelf);
        }
    }
}
