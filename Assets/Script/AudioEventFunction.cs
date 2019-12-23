using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class AudioEventFunction : MonoBehaviour 
{
	private AudioSource newaudio;
    [Header("資料格式(SFXData): 音訊檔案--音量(0~1)")]
    public AudioData[] AudioState ;

	void Start() 
	{
		newaudio = GetComponent<AudioSource>();
	}

	public void PlayAudioOnce(int index) 
	{
		newaudio.PlayOneShot(AudioState[index].audioFX, AudioState[index].volume);
	}
}
