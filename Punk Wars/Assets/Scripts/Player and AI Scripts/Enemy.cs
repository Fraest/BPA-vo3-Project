using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Healthbar healthbar;
    private float countdown = 5f;
    public float timer;

    private int wavepointIndex = 0;
    // private Spawner waveSpawner;
    private HealthManager hm;
    private Gameloop gameloop;


    void Awake()
    {
        gameloop = GameObject.FindWithTag("HQ").GetComponent<Gameloop>();
        // gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(new Vector3(168.042603f,9.2204237f,-42.0311279f)); 
        timer = 0;
    }

    private void Start()
    {
        // waveSpawner = GetComponentInParent<Spawner>();
        hm = gameObject.GetComponent<HealthManager>();
        healthbar.UpdateHealthbar(hm.maxHealth, hm.health);
    }
    private void Update()
    {
        if (hm.health == 0)
        {
            Destroy(gameObject);
            gameloop.IncrementPoints(5);
        }
        healthbar.UpdateHealthbar(hm.maxHealth, hm.health);

        timer += Time.deltaTime;
        if(timer >= 2){
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(gameObject.transform.position); 
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = GameObject.FindWithTag("HQ").transform.position;
        }
    }
}
