using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class WayPointManager : MonoBehaviour
{
    [Header("Customise Look of Paths")]
	public Color gizmoColor = Color.black;

	//list to hold the gameobject path points
	[Header("WayPointManager")]
	[Tooltip("This is the list that holds all the Waypoint Points")]
	public List<GameObject> pathPoints = new List<GameObject>(); 
	//the main pathfinder object this script is attached to.
	GameObject pathFinder;
	//the new path point to create
	GameObject pathPoint;



    //Build One Point
#if UNITY_EDITOR
    public void BuildPath()
    {
		pathFinder = this.gameObject;
        pathPoint = new GameObject (GameObjectUtility.GetUniqueNameForSibling(pathFinder.transform, "Point"));
        pathPoint.transform.parent = pathFinder.transform;
        //GameObjectUtility.GetUniqueNameForSibling(pathFinder.transform, "Point");
        pathPoint.AddComponent<WaypointGizmos> ();
        pathPoints.Add (pathPoint);
	}
#endif

    //Clear All Paths
#if UNITY_EDITOR
    public void ClearPath()
    {
		foreach (GameObject go in pathPoints)
        {
			DestroyImmediate (go);
		}
		pathPoints.Clear ();
	}
#endif

    //What the AI system Accesses to get the paths.
    public List<GameObject> CreatedPaths 
	{
		get { return pathPoints; }
	}

    // Update is called once per frame
#if UNITY_EDITOR
    void OnDrawGizmos ()
    {
		for (var i = 1; i < pathPoints.Count; i++)
        {
			Gizmos.color = gizmoColor;
			Gizmos.DrawLine (pathPoints [i - 1].transform.position, pathPoints [i].transform.position);
		}
    }
#endif
}
