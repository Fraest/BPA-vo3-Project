using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.AI;

public class CreateOres : MonoBehaviour
{
    [SerializeField] NavMeshData navData;
    System.Collections.Generic.List<UnityEngine.AI.NavMeshBuildSource> buildSources;
    System.Collections.Generic.List<UnityEngine.AI.NavMeshBuildMarkup> markups;

    // Start is called before the first frame update
    void Start()
    {
        //creating the variables to use in the UpdateNavMeshData function
        Bounds bounds = new Bounds(new Vector3(0,0,0), new Vector3(52,3,-53));
        NavMeshBuildSettings buildSettings = gameObject.GetComponent<NavMeshSurface>().GetBuildSettings();
        // GameObject[] level = GameObject.FindGameObjectsWithTag("Level");
        
        UnityEngine.AI.NavMeshBuilder.CollectSources(bounds, 8, NavMeshCollectGeometry.RenderMeshes, 0, markups, buildSources);
        //update the navmesh
        UnityEngine.AI.NavMeshBuilder.UpdateNavMeshData(navData, buildSettings, buildSources, bounds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
