// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Fungus
{
	/// <summary>
	/// Writes text in a dialog box.
	/// </summary>
	[CommandInfo("Replace", 
		"Replace Material",
        "Replace Source Object Material.")]
	[AddComponentMenu("")]
	[ExecuteInEditMode]
	public class ReplaceMaterial : Command
	{
        [Tooltip("Source Object")]
        [SerializeField] private GameObject _targetObject;

        [Tooltip("Source Object Material Index")]
		[SerializeField] private int _materialIndex = 0;

		[Tooltip("Target Material")]
		[SerializeField] private Material _targetMaterial;

        private Renderer rend;
        
        void OnEnable()
		{
            
		}
        
        /*
		protected virtual void OnWaitComplete()
		{
			Continue();
		}
        */

		#region Public members

		public override void OnEnter()
		{
            ReplaceIndexMaterial(_targetObject, _materialIndex, _targetMaterial);
            Continue();
        }

		public override string GetSummary()
		{
            if (_targetObject == null)
            {
                return "Error: No game object selected";
            }
            if (_targetMaterial == null)
            {
                return "Please Assign Material !!!";
            }
            else
            {
                return _targetObject.name.ToString() + " Materials[ " + _materialIndex.ToString() + " ]  Replace as " + _targetMaterial.name;
            }
            
		}

		public override Color GetButtonColor()
		{
			return new Color32(174, 83, 255, 255);
		}

		#endregion

		private void ReplaceIndexMaterial( GameObject _source , int _index , Material _material )
		{
			
			if (_source == null || _material == null )
			{
				return;
			}
			else
			{
                rend = _source.GetComponent<Renderer>();
                Debug.Log(rend.name);
                //rend.materials[_index] = _material;
                //rend.sharedMaterials[_index] = _material;
                
                Material[] mats = rend.sharedMaterials;
                mats[_index] = _material;
                rend.sharedMaterials = mats;
                
                Debug.Log(rend.sharedMaterials[_index].name);
            }
		}
        		
	}

}
