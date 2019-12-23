using UnityEngine;
using System.Collections;

public class TeleporterDelay : MonoBehaviour 
{
	public Transform goal;
	public float delayTime = 0.0f;


	void OnTriggerEnter(Collider other) 
	{
		StartCoroutine(Teleporter(delayTime , other));
	}

	IEnumerator Teleporter(float dtime , Collider player)
	{
		yield return new WaitForSeconds(dtime);
		player.transform.position = goal.position;
	}
}
