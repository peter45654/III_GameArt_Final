using UnityEngine;
using System.Collections;

public class RotateAroundCenter : MonoBehaviour
{
    public float rotationSpeed = 3.0f;
		
	// Update is called once per frame
	void Update ()
    {
        transform.RotateAround(Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
