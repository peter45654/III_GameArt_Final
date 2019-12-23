using System.Collections;
using UnityEngine;
using Fungus;

public class FlowchartDataPlayer : MonoBehaviour
{
    [Header("")]
    [Header("          Flowchart名稱--Block名稱")]
    [Header("          註解")]
    
    public FlowchartData[] BlockData;


    public void PlayFlowchartData(int index)
    {
        if (BlockData[index].flowchart != null && BlockData[index].block != null)
        {
            BlockData[index].flowchart.ExecuteBlock(BlockData[index].block);
        }    

    }
}
