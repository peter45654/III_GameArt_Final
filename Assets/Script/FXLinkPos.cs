using UnityEngine;
using System.Collections;

public class FXLinkPos : MonoBehaviour
{

    //public static Transform _TargetPos;

    public Transform linkPos;
    //private Transform _TargetPos;

    void Awake()
    {
        //_TargetPos = linkPos;
    }

    void LateUpdate()
    {
        //if (_TargetPos)
        //{
            this.transform.position = linkPos.position;
        //}
    }
}
