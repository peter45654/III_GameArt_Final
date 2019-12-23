using UnityEngine;
using System.Collections;
using Fungus;

namespace Fungus
{
	public class Trigger3D : MonoBehaviour 
	{
        [Tooltip("Is object Trigger enabled")]
        public bool IsTriggerEnabled = true;

        [Tooltip("Compare Collider Tag")]
        public string TagName = "";
        		

        [Header("UI Interact Settings(Work Correct Only in OnTriggerStay)")]
        [Tooltip("PressButton function Enabled")]
        public KeyCode interactKey;

        [Tooltip("Display UI)")]
        public bool displayUI;
        public GameObject interactDisplay;

        private bool playerInZone = false;

        void Start()
        {
            ToggleInteractUI(false);
        }

		public void SetTriggerWork(bool newstate)
		{
			IsTriggerEnabled = newstate;
		}

		public void PlayerEnteredZone()
        {
            playerInZone = true;
            ToggleInteractUI(playerInZone);
            
        }

        public void PlayerExitedZone()
        {
            playerInZone = false;
            ToggleInteractUI(playerInZone);
        }

        private void ToggleInteractUI(bool newState)
        {
            if (displayUI)
            {
                interactDisplay.SetActive(newState);
            }
        }

        protected virtual void OnTriggerEnter (Collider Other)
		{
            if(IsTriggerEnabled == true)
            {
                if(CompareColliderTag(TagName , Other) == true)
                {
                    DoTriggerEnter();
                    PlayerEnteredZone();
                }
            }
   		}

		protected virtual void OnTriggerExit (Collider Other)
		{
            if (IsTriggerEnabled == true)
            {
                if (CompareColliderTag(TagName, Other) == true)
                {
                    DoTriggerExit();
                    PlayerExitedZone();
                }
            }
		}

		protected virtual void OnTriggerStay (Collider Other)
		{
            if (IsTriggerEnabled == true)
            {
				if (CompareColliderTag (TagName, Other) == true) 
				{
                    //沒有設定按鍵
                    if (interactKey == KeyCode.None)
                    { DoTriggerStay(); }
                    else
                    {
                        //有設定按鍵
                        if (IsButtonPressed())
                        {
                            DoTriggerStay();
                            ToggleInteractUI(false);
                        }
                    }
    			}
            }
		}

        private bool CompareColliderTag (string _Tagname , Collider _Other)
        {
            if (_Tagname == "")
            {
                return true;
            }
            else
            {
                if (_Other.CompareTag(_Tagname))
                { return true; }
                else
                { return false; }
            }
        }

		private bool IsButtonPressed ()
		{
			var activateTimelineInput = Input.GetKey (interactKey);

			if (activateTimelineInput)
            {
				return true;
			}
            else
            {
				return false;
			}
		}

        
        protected virtual void DoTriggerEnter()
		{
			// TODO: Cache these objects for faster lookup
			TriggerEnabled[] handlers = GameObject.FindObjectsOfType<TriggerEnabled>();
			foreach (TriggerEnabled handler in handlers)
			{
				handler.OnTriggerEnabledEnter(this);
			}
		}

		protected virtual void DoTriggerExit()
		{
			// TODO: Cache these objects for faster lookup
			TriggerEnabled[] handlers = GameObject.FindObjectsOfType<TriggerEnabled>();
			foreach (TriggerEnabled handler in handlers)
			{
				handler.OnTriggerEnabledExit(this);
			}
		}

		protected virtual void DoTriggerStay()
		{
			// TODO: Cache these objects for faster lookup
			TriggerEnabled[] handlers = GameObject.FindObjectsOfType<TriggerEnabled>();
			foreach (TriggerEnabled handler in handlers)
			{
				handler.OnTriggerEnabledStay(this);
			}
		}



	}

}