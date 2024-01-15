using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos, zPos, enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
        StartCoroutine(EnemyDrop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyDrop(){
        while(enemyCount < 100){
            xPos = Random.Range(1,50);
            zPos = Random.Range(1,50);
            Instantiate(theEnemy, new Vector3(xPos, 15, zPos), Quaternion.identity);
            yield return new WaitForSeconds(15);
            enemyCount++;
        }
    }
}
