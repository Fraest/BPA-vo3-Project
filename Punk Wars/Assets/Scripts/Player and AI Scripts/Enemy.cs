using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Healthbar healthbar;
    private float countdown = 5f;

    private int wavepointIndex = 0;
    private Transform target;
    private Spawner waveSpawner;
    private HealthManager hm;
    private Gameloop gameloop;

    public float speed = 2f;


    void Awake()
    {
        gameloop = GameObject.FindWithTag("HQ").GetComponent<Gameloop>();
    }

    private void Start()
    {
        target = Waypoints.point[0];
        waveSpawner = GetComponentInParent<Spawner>();
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

        Vector3 dir = target.position - transform.position;
        // transform.Translate(dir.normalized * speed * Time);
    }
}
