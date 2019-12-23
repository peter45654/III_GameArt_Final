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
		"Replace Texture",
        "Replace Selection's Material Texture.")]
	[AddComponentMenu("")]
	[ExecuteInEditMode]
	public class ReplaceTexture : Command
	{
        [Tooltip("Source Object")]
        [SerializeField] private GameObject _sourceObject;

        [Tooltip("Source Object Material Index")]
		[SerializeField] private int _materialIndex = 0;

        [Tooltip("Index Material Texture Channel")]
        [SerializeField] private string _textureName = "_MainTex";

        [Tooltip("Target Texture")]
		[SerializeField] private Texture _targetTexture;

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
            ReplaceIndexMaterial(_sourceObject, _materialIndex, _targetTexture);
            Continue();
        }

		public override string GetSummary()
		{
            if (_sourceObject == null)
            {
                return "Error: No game object selected";
            }
            if (_targetTexture == null)
            {
                return "Please Assign Texture !!!";
            }
            else
            {
                return _sourceObject.name.ToString() + " Materials[ " + _materialIndex.ToString() + " ]  Texture Replace as " + _targetTexture.name;
            }
            
		}

		public override Color GetButtonColor()
		{
			return new Color32(174, 83, 255, 255);
		}

		#endregion

		private void ReplaceIndexMaterial( GameObject _source , int _index , Texture _texture )
		{
			
			if (_source == null || _texture == null )
			{
				return;
			}
			else
			{
                rend = _source.GetComponent<Renderer>();

                //Texture2D _loadtexture = Resources.Load();
                //Debug.Log(rend.name);
                //rend.materials[_index] = _material;
                //rend.sharedMaterials[_index] = _material;

                //rend.sharedMaterials[_index].mainTexture = _texture;
                        
                rend.sharedMaterials[_index].SetTexture(_textureName, _targetTexture);

                //Debug.Log(rend.sharedMaterials[_index].name);
            }
		}
        		
	}

}
