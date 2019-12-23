using UnityEngine;
using System;

[Serializable]
public class FXData 
{
    public GameObject fX;
    public Transform fX_position;
    public float fX_delay;
    public float fX_delete;
    public linktype fX_linktype;
    public enum linktype
    {
        None = 0,
        LinkPos = 1,
        LinkTransform = 2
    }
}

/*
[Serializable]
public enum linktype
{
    None          = 0 ,
	LinkPos       = 1 ,
	LinkTransform = 2 
}
*/