using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private GameObject spawnPoint;
    public Wave[] waves;
    public int currentWaveIndex = 0;

    private bool readyToCountDown;

    

    //starts the countdown for spawning
    private void Start()
    {
        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }

    private void Update()
    {
        //Checks to see if all waves have been destroyed
        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("CONGRATS!!!!! .....now do it again");
            return;
        }

        //Stops counter if less than zero
        if (countdown <= 0)
        {
            readyToCountDown = false;

            countdown = waves[currentWaveIndex].timeToNextWave;

            StartCoroutine(SpawnWave());
        }

        //Starts it after enemies have been destroyed
        if (waves[currentWaveIndex].enemiesLeft == 0)
        {
            readyToCountDown = true;

            currentWaveIndex++;
        }

        //Makes sure counter is reset and then starts counting
        if (readyToCountDown == true)
        {
            countdown -= Time.deltaTime;
        }
    }

    //Check current wave and sets timer for waiting between enemy spawns and waves
    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
            {
                Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint.transform.position, new Quaternion(0,0,0,1), spawnPoint.transform);

                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }
    }
}

[System.Serializable]
public class Wave
{
    public Enemy[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;

    [HideInInspector] public int enemiesLeft;
}