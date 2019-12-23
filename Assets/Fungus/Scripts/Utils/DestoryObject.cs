using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour {

    public float lifetime = 10f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

   
}
