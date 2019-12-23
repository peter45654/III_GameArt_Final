// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Fungus
{
    /// <summary>
    /// Direction of Face to Target"
    /// </summary>
    [CommandInfo("Vector3",
                 "Direction of Face to Target",
                 "Direction of Face to Target ")]
    [AddComponentMenu("")]
    //[ExecuteInEditMode]
    public class DirectionofFacetoTarget : Command
    {
        [Tooltip("Name of Source Object")]
        [SerializeField] protected GameObjectData _sourceObject;

        [Tooltip("Name of Target Object")]
        [SerializeField] protected GameObjectData _targetObject;

        [Tooltip("Set a Threshold to Defination Distance")]
        [SerializeField] protected Vector3Data _direction ;
     


        #region Public members

        public override void OnEnter()
        {
            if (_sourceObject.Value == null)
            {
               Continue();
            }
            if (_targetObject.Value == null)
            {
               Continue();
            }
            Vector3 direction = new Vector3(_targetObject.Value.transform.position.x - _sourceObject.Value.transform.position.x,
                                        0.0f,
                                        _targetObject.Value.transform.position.z - _sourceObject.Value.transform.position.z);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _direction.Value = targetRotation.eulerAngles; 
            //_sourceObject.Value.transform.rotation = Quaternion.Lerp(_sourceObject.Value.transform.rotation , targetRotation , _speed.Value * Time.deltaTime);


            Continue();
        }
          

        public override string GetSummary()
        {
            if (_sourceObject.Value == null)
            {
                return "Error: No Source Object selected";
            }

            if (_targetObject.Value == null)
            {
                return "Error: No Target Object selected";
            }
            return _sourceObject.Value.name.ToString() + " Face to "+ _targetObject.Value.name.ToString() + ": Speed "  ;
        }

        public override Color GetButtonColor()
        {
            return new Color32(96, 191, 156, 255);
        }

        #endregion

        #region Backwards compatibility
        /*
        [HideInInspector] [FormerlySerializedAs("animator")] public Animator animatorOLD;
        [HideInInspector] [FormerlySerializedAs("parameterName")] public string parameterNameOLD = "";

        protected virtual void OnEnable()
        {
            if (animatorOLD != null)
            {
                _animator.Value = animatorOLD;
                animatorOLD = null;
            }

            if (parameterNameOLD != "")
            {
                _parameterName.Value = parameterNameOLD;
                parameterNameOLD = "";
            }
        }
        */
        #endregion
    }
}