using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WayPointManager))]
public class WayPointManagerEditor : Editor {


	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

        WayPointManager myScript = (WayPointManager)target;



		if(GUILayout.Button("Build WayPoint"))
		{
			myScript.BuildPath();
		}

		if (GUILayout.Button ("Clear All WayPoints")) 
		{
			myScript.ClearPath ();

		}



	}



}
