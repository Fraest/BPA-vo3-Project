// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Mono.Data.Sqlite;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// using System.Data;

// public class SaveManager : MonoBehaviour
// {
//     string dbName = "URI=file:Database.db";

//     private void Awake()
//     {
//         if (!Directory.Exists(Application.streamingAssetsPath + "/Saves/"))
//         {
//             Directory.CreateDirectory(Application.streamingAssetsPath + "/Saves/");
//         }
//         DontDestroyOnLoad(gameObject);
//     }

//     // Start is called before the first frame update
//     void Start()
//     {
//         if (!File.Exists("Database.db"))
//             CreateDB();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         public void CreateDB()
//         {
//             // Create DB connection
//             using (var Connection = new SqliteConnection(dbName))
//             {
//                 Connection.Open();

<<<<<<< Updated upstream
//                 // set up an object command to control db
//                 IDbCommand Command = Connection.CreateCommand();

//                 // Creating the Unit Table if it doesn't already exist
//                 Command.CommandText = "CREATE TABLE IF NOT EXISTS Main (id INTEGER, UnitHP INTEGER, UnitXPosition INTEGER, UnitYPosition INTEGER, UnitZPosition INTEGER, OnYourTeam INTEGER);";
//                 Command.ExecuteReader();

//                 Command = Connection.CreateCommand();

//                 //Creating the Player Table if it doesn't already exist
//                 Command.CommandText = "CREATE TABLE IF NOT EXISTS Player (id INTEGER, Copper INTEGER, Iron INTEGER, BaseHP);";
                
//                 Command = Connection.CreateCommand();

//                 Connection.Close();
//             }
//         }
//     }
=======
                // set up an object command to control db
                IDbCommand Command = Connection.CreateCommand();
>>>>>>> Stashed changes

//     public string Read(string table, string column, int row)
//     {
//         using (SqliteConnection connection = new SqliteConnection(dbName))
//         {
//             connection.Open();
//             SqliteCommand cmd = new SqliteCommand("SELECT " + column + " FROM " + table + " WHERE id = " + row.toString(), connection);
//             SqliteDataReader reader = cmd.ExecuteReader();

//             return reader.GetValue(0).ToString();
//         }
//     }

//     public void Write(string table, string column, int row, string variableToUse)
//     {
//         using (var connection = new SqliteConnection(dbName))
//         {
//             connection.Open();

//             //Setting up an object command to allow db caontrol
//             using (var command = connection.CreateCommand())
//             {
//                 // command.CommandText = "SELECT DISTINCT " + column + " FROM " + table + " WHERE id = " + row.ToString() + " ORDER BY id;";
//                 // command.ExecuteNonQuery();

//                 // //IDataReader dataReader = command.ExecuteReader();
//                 // command.CommandText = "UPDATE " + table + " SET " + column + " = " + variableToUse + " WHERE id = " + row.ToString();
//                 // command.ExecuteNonQuery();
//             }
//             connection.Close();
//         }
//     }

<<<<<<< Updated upstream
//     public void DeleteAndRecreateDatabase()
//     {
//         File.Delete("Database.db");
//         CreateDB();
//     }
// }
=======
            return reader.GetValue(0).ToString();
        }
    }

    public void Write(string table, string column, int row, string variableToUse)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            //Setting up an object command to allow db caontrol
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT DISTINCT " + column + " FROM " + table + " WHERE id = " + row.ToString() + " ORDER BY id;";
                command.ExecuteNonQuery();

                IDataReader dataReader = command.ExecuteReader();
                command.CommandText = "UPDATE " + table + " SET " + column + " = " + variableToUse + " WHERE id = " + row.ToString();
                Command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void DeleteAndRecreateDatabase()
    {
        File.Delete("Database.db");
        CreateDB();
    }
}
>>>>>>> Stashed changes
