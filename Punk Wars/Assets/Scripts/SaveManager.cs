using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;

public class SaveManager : MonoBehaviour
{
    string dbName = "URI=file:Database.db";

    private void Awake()
    {
        if (!Directory.Exists(Application.streamingAssetsPath + "/Saves/"))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath + "/Saves/");
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists("Database.db"))
            CreateDB();
    }

    // Update is called once per frame
    void Update()
    {
        public void CreateDB()
        {
            // Create DB connection
            using (var Connection = new SqliteConnection(dbName))
            {
                Connection.Open();

                // set up an object command to control db
                IDbCommand Command = Connection.CreateCommand();
            }
}