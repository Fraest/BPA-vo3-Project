using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    HealthManager hm;
    [SerializeField] private Healthbar healthbar;
    private Gameloop gameloop;


    void Awake() {
        gameloop = GameObject.FindWithTag("HQ").GetComponent<Gameloop>();
    }


    // Start is called before the first frame update
    void Start()
    {
        hm = gameObject.GetComponent<HealthManager>();
        healthbar.UpdateHealthbar(hm.maxHealth, hm.health);
    }


    // Update is called once per frame
    void Update()
    {
        if(hm.health == 0){
            Destroy(gameObject);
            gameloop.IncrementPoints();
        }
        healthbar.UpdateHealthbar(hm.maxHealth, hm.health);
    }
}
