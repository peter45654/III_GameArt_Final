using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Fungus;

namespace Fungus 
{
	[EventHandlerInfo("",
		"Trigger Enabled",
		"The block will execute when the Trigger is Enabled.")]
	[AddComponentMenu("")]
	public class TriggerEnabled : EventHandler 
	{	
		[Tooltip("Object that is Setup as Trigger")]
		public Trigger3D Trigger3D_Object;

		public enum TriggerType {TriggerEnter, TriggerExit, TriggerStay};
		public TriggerType triggerType;
		//public float MinDistance = 3f;
		/*
		public virtual void Start()
		{
			
		}
		*/

		public virtual void OnTriggerEnabledEnter (Trigger3D tTrigger3D_Object)
		{
			if (triggerType == TriggerType.TriggerEnter) 
			{
				if (tTrigger3D_Object == this.Trigger3D_Object) 
				{
					ExecuteBlock ();
				}
			}
		}

		public virtual void OnTriggerEnabledExit (Trigger3D tTrigger3D_Object)
		{
			if (triggerType == TriggerType.TriggerExit) 
			{
				if (tTrigger3D_Object == this.Trigger3D_Object) 
				{
					ExecuteBlock ();
				}
			}
		}

		public virtual void OnTriggerEnabledStay (Trigger3D tTrigger3D_Object)
		{
			if (triggerType == TriggerType.TriggerStay) 
			{
				if (tTrigger3D_Object == this.Trigger3D_Object) 
				{
					ExecuteBlock ();
				}
			}
		}

		protected virtual void DoEvent()
		{
			ExecuteBlock();
		}

		/*
		public override string GetSummary()
		{
			if (clickableObject != null)
			{
				return clickableObject.name;
			}

			return "None";
		}
		*/
	}
}