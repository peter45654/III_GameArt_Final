using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [Header("TimelineDirector")]
    public PlayableDirector playableDirector;

    [Header("TimelineAsset")]
    public List<TimelineAsset> timelineAssets;

    [Header("Player Timeline Position")]
    public bool setPlayerTimelinePosition = false;
    public Transform playerTimelinePosition;

    [Header("Player Data")]
    public string playerTag = "Player";
    private GameObject playerObject;
   
    private bool timelinePlaying = false;
    private float timelineDuration;

    void Start()
    {
        if (playerTag == "")
        {
            Debug.Log("請指定玩家tag名稱！");
        }
        else
        {
            playerObject = GameObject.FindWithTag(playerTag);
            if (playerObject == null)
            {
                Debug.Log("請指定tag:player物件！");
            }
        }
     
    }

    public void TimelineManagerPlay(int index)
    {
        if (!timelinePlaying)
        {
            PlayTimeline(index);
        }
    }

    private void PlayTimeline(int index)
    {
        TimelineAsset selectasset;
        if (timelineAssets.Count == 0)
        {
            return;
        }
        else
        {
            if (index > (timelineAssets.Count-1) )
            {
                Debug.Log("指定的Timeline素材編號超出範圍！");
                return;
            }
            else
            {
                selectasset = timelineAssets[index];
            }
        }

        if (setPlayerTimelinePosition)
        {
            SetPlayerToTimelinePosition();
        }
        if (playableDirector)
        {
            playableDirector.Play(selectasset);
        }
        timelinePlaying = true;
        StartCoroutine(WaitForTimelineToFinish());
    }

    IEnumerator WaitForTimelineToFinish()
    {
        
        timelineDuration = (float)playableDirector.duration;
        
        yield return new WaitForSeconds(timelineDuration);
                
        timelinePlaying = false;
    }
   
    void SetPlayerToTimelinePosition()
    {
        if (playerObject == null)
        {
            Debug.Log("請指定tag:player物件！");
        }
        else if (playerTimelinePosition == null)
        {
            Debug.Log("請指定playerTimelinePosition位置！");
        }
        else
        {
            playerObject.transform.position = playerTimelinePosition.position;
            playerObject.transform.localRotation = playerTimelinePosition.rotation;
        }
        
    }
}