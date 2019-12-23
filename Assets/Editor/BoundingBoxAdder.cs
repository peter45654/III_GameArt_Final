using UnityEngine;
using UnityEditor;
using System.Collections;

public class BoundingBoxAdder : AssetPostprocessor {
	void OnPostprocessModel(GameObject g)
	{
		// filter out only animations.
		string lowerCaseAssetPath = assetPath.ToLower();
		
		if (lowerCaseAssetPath.IndexOf("/_collider/") == -1)  //do this ONLY if we are in the ENVIRONMENT FOLDER, assets/environment/...
			return;
		
		Apply(g.transform);
		
	}
	
	
	// Add a mesh collider to each game object that contains collider in its name
	void Apply (Transform transform){
		if (transform.name.ToLower().Contains("collider")){
			transform.gameObject.AddComponent(typeof(MeshCollider));
			
			Object[] smr = transform.gameObject.GetComponentsInChildren(typeof(MeshRenderer), false);
			Object[] mfs = transform.gameObject.GetComponentsInChildren(typeof(MeshFilter), false);
			
			foreach (MeshRenderer o in smr){
				Object.DestroyImmediate(o, true);
			}
			foreach (MeshFilter mf in mfs){
				Object.DestroyImmediate(mf, true);
			}
		}
		
		// Recurse
		foreach(Transform child in transform)
			Apply(child);
	}
}
