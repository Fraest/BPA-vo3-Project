using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    HealthManager hm;

    // Start is called before the first frame update
    void Start()
    {
        hm = gameObject.GetComponent<HealthManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if(hm.health == 0){
            //does this so onTriggerExit actually plays out
            gameObject.transform.position = gameObject.transform.position + new Vector3(0,100,0);
            Destroy(gameObject);
        }
    }
}
