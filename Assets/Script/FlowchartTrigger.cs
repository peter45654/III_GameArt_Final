using UnityEngine;
using System.Collections;
using Fungus;
//using UnityStandardAssets.Characters.FirstPerson;

public class FlowchartTrigger : MonoBehaviour 
{
    [SerializeField]
    private Flowchart flowchart;

    [SerializeField]
    private string block ;

    [SerializeField]
    private bool isCheck = false;

    [SerializeField]
    private string colliderName;

    [SerializeField]
    private string colliderTag;

    //public FirstPersonController fpsController; 

    void OnTriggerEnter(Collider other)
    {
        //fpsController.enabled = false;
        if (flowchart != null && block != null)
        {
            if (isCheck == false)
            {
                flowchart.ExecuteBlock(block);
            }
            else
            {
                if (colliderName != null)
                {
                    if (other.gameObject.name == colliderName)
                    {
                        flowchart.ExecuteBlock(block);
                    }
                }
                else
                {
                    if (colliderTag != null)
                    {
                        if (other.gameObject.tag == colliderTag)
                        {
                            flowchart.ExecuteBlock(block);
                        }
                    }
                }
          
            }
        }
            
     }
 }