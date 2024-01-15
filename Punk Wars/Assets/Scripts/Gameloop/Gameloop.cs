using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;
using TMPro;

public class Gameloop : MonoBehaviour
{
    public int id = 1, copper = 0;
    private SaveManager savemanager;
    private Menu1 menu1;
    private float timer = 0;
    private TMP_Text scoreCounter, copperCounter;

    int points = 0, blah; //added blah for compiler error reasons
    void Start() {
        scoreCounter = GameObject.FindWithTag("ScoreCounter").GetComponent<TMP_Text>();
        copperCounter = GameObject.FindWithTag("CopperCounter").GetComponent<TMP_Text>();
    }
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
                // savemanager.Write("Scores", "Score", id);
            }
        }

        timer += Time.deltaTime;
        if(timer >= 1){
            IncrementPoints(1);
            timer = 0;
        }

        copperCounter.text = "Copper: " + copper.ToString();
    }

    public void IncrementPoints(int reward)
    {
        points = points + reward;
        scoreCounter.text = "Score: " + points.ToString();
    }
}