// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.Collections;

namespace Fungus
{
    /// <summary>
    /// Play timeline asset in scene.
    /// </summary>
    [CommandInfo("Timeline", 
		"PlayTimelineAsset", 
		"Play Timeline Asset in Scene.")]
	[AddComponentMenu("")]
	//[ExecuteInEditMode]
	public class PlayTimelineAsset : Command
	{
		[Tooltip("The PlayableDirector Which Play the Timeline Asset")]
		[SerializeField] protected PlayableDirector _playableDirector;

		[Tooltip("The PlayableAsset That want to Play")]
		[SerializeField] protected PlayableAsset _playableAsset;

        /*
		[Tooltip("Wait for PlayableAsset to Finish.")]
		[SerializeField] protected bool waitForFinish = true;
        */
        [Tooltip("The type of keypress to activate on")]
        [SerializeField]
        protected KeyPressType keyPressType;

        [Tooltip("Keycode of the key to activate on")]
        [SerializeField]
        protected KeyCode keyCode;

        protected float playableAssetDuration = 0.0f;

       

        protected virtual void Start()
        {
            if(_playableAsset != null)
            playableAssetDuration = (float)_playableAsset.duration;
        }

        protected virtual void OnWaitComplete()
        {
			Continue();
		}


		#region Public members

		public override void OnEnter()
		{
            if (_playableDirector != null && _playableAsset != null)
            {
                //if (waitForFinish)
                {
                    Invoke("OnWaitComplete", playableAssetDuration);
                   
                }
            }
            PlayTimeline(_playableDirector, _playableAsset);
            
        }

        protected virtual void Update()
        {
            switch (keyPressType)
            {
                case KeyPressType.KeyDown:
                    if (Input.GetKeyDown(keyCode))
                    {
                        CancelInvoke();
                        Continue();
                    }
                    break;
                case KeyPressType.KeyUp:
                    if (Input.GetKeyUp(keyCode))
                    {
                        CancelInvoke();
                        Continue();
                    }
                    break;
                case KeyPressType.KeyRepeat:
                    if (Input.GetKey(keyCode))
                    {
                        CancelInvoke();
                        Continue();
                    }
                    break;
            }
        }

        /*
        public override void OnStopExecuting()
        {
            if (_playableDirector == null || _playableAsset == null)
            {
                return;
            }

            StopTimeline(_playableDirector);
        }
        */

        public override string GetSummary()
		{
            //string description = ("Play " + _playableAsset.name.ToString() +" : "+ _playableAsset.duration.ToString() + " seconds");
            if (_playableDirector == null)
            {
                return "Error: No PlayableDirector Selected";
            }
            if (_playableAsset == null)
            {
                return "Error: No PlayableAsset Selected";
            }

            return ("Play " + _playableAsset.name.ToString() + " : " + _playableAsset.duration.ToString() + " seconds");
        }
        
		public override Color GetButtonColor()
		{
			return new Color32(255, 205, 146, 255);
		}

		#endregion

		protected void PlayTimeline( PlayableDirector _director , PlayableAsset _asset)
		{
			
			if ( _director== null || _asset == null )
			{
				return;
			}
			else
			{
				_director.Play(_asset);
			}
		}

        protected void StopTimeline(PlayableDirector _director)
        {

            if (_director == null )
            {
                return;
            }
            else
            {
                _director.Stop();
            }
        }

    }

}
