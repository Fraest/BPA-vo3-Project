using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.AI;

public class CreateOres : MonoBehaviour
{
    //!!!!!!!!!!!!!!finish later
    [SerializeField] NavMeshData navData;
    [SerializeField] NavMeshBuildSettings buildSettings;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] level = GameObject.FindGameObjectsWithTag("Level");
        // NavMeshBuilder.UpdateNavMeshData(navData);
        gameObject.GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
