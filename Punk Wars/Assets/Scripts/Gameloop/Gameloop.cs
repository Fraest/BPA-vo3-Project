using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;

public class Gameloop : MonoBehaviour
{
    public int id = 1;
    private SaveManager savemanager;
    private Menu1 menu1;

    int points = 0, blah; //added blah for compiler error reasons
    void Update()
    {
        // Create a temporary reference to the current scene.
		Scene currentScene = SceneManager.GetActiveScene();

		// Retrieve the name of this scene.
		string sceneName = currentScene.name;

        if(sceneName == "MainLevel")
        {
            if(blah > 0)  // blah to be replaced by the health value of the HQ
            {

            }
            else
            {
                savemanager.Write("Scores", "Score", id);
            }
        }
    }

    public void IncrementPoints()
    {
        points = points + 10;
    }
}