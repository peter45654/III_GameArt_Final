using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]

public class TrailEventFunction : MonoBehaviour 
{
	//private AudioSource newaudio;
    [Header("資料格式(TrailData): Trail目標--顯示時間(秒)")]
    public TrailData[] trailState ;


    //[SerializeField]

    private Animator _animator;
    //private AnimatorClipInfo[] _animatorClipInfo;

    //AnimationState _animationState;
    private MeleeWeaponTrail _trail;
    private float _waittime;

   void Start() 
	{
        //newaudio = GetComponent<AudioSource>();
        //_animator = GetComponent<Animator>();
        //_animatorClipInfo = _animator.GetCurrentAnimatorClipInfo(0);
    }

	public void PlayTrail(int index) 
	{
        
       // if (trailState[index].trailAnimator == _animator)
        {
            //啟動刀光
            //_waittime = (trailState[index].endFrame - trailState[index].startFrame) / _animatorClipInfo[0].clip.frameRate;
            //如有改變播放速度
            _waittime = trailState[index].displayTime;
            _trail = trailState[index].trail;
            _trail.Emit = true;
            //關閉刀光
            StartCoroutine(CloseTrail(_waittime));
        }
    }

    IEnumerator CloseTrail(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        _trail.Emit = false;
        //Do Function here...
    }

}
