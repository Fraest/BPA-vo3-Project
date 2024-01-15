using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private float countdown = 5f;
    private Spawner waveSpawner;
    HealthManager hm;
    [SerializeField] private Healthbar healthbar;
    private Gameloop gameloop;

    void Awake()
    {
        gameloop = GameObject.FindWithTag("HQ").GetComponent<Gameloop>();
    }

    private void Start()
    {
        waveSpawner = GetComponentInParent<Spawner>();
        hm = gameObject.GetComponent<HealthManager>();
        healthbar.UpdateHealthbar(hm.maxHealth, hm.health);
    }
    private void Update()
    {
        if (hm.health == 0)
        {
            Destroy(gameObject);
            gameloop.IncrementPoints();
        }
        
        healthbar.UpdateHealthbar(hm.maxHealth, hm.health);
    }
}
