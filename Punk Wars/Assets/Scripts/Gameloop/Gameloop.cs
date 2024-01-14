using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;

public class Gameloop : MonoBehaviour
{
    int points = 0;
    void Update()
    {
        if(blah > 0)  // blah to be replaced by the health value of the HQ
        {
            
        }
        else
        {
            
        }
    }

    public void IncrementPoints()
    {
        points = points + 10;
    }
}