using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu1 : MonoBehaviour
{
    //Increases build index by 1 to go to the next scene in the index
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Closes App
    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}
