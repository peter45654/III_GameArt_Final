using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class StaticRemoveAnim : MonoBehaviour 
{

	[MenuItem("DCI/Delete Static Animation(or)")]
	static public void Remove()
	{
		
		GameObject []rootObjects = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		
		foreach(GameObject go in rootObjects)
		{
			
			if( go.isStatic == true )
			{
				
				Animation animation = go.GetComponent<Animation>();
				{
					if(animation != null)
					DestroyImmediate(animation);
				}
				Animator animator = go.GetComponent<Animator>();
				{
					if(animator != null)
					DestroyImmediate(animator);
				}
			}
		}
		
		AssetDatabase.SaveAssets();
	}
}