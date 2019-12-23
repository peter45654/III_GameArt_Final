// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Fungus
{
    /// <summary>
    /// Confirm if enemy is within distance And Return a boolean value"
    /// </summary>
    [CommandInfo("NavMeshAgent",
                 "Is In Range",
                 "Confirm if Enemy is Within Distance")]
    [AddComponentMenu("")]
    //[ExecuteInEditMode]
    public class IsInRange : Command
    {
        [Tooltip("Name of Target")]
        [SerializeField] protected GameObjectData _target;

        [Tooltip("Name of the boolean Animator parameter that will have its value changed")]
        [SerializeField] protected GameObjectData _enemy;

        [Tooltip("Set a Threshold to Defination Distance")]
        [SerializeField] protected FloatData _distance ;

        [Tooltip("Return Bool Value to a Variable")]
        [SerializeField] protected BooleanData _returnValue;

        #region Public members

        public override void OnEnter()
        {
            if ((_target.Value.transform.position - _enemy.Value.transform.position).sqrMagnitude < _distance.Value* _distance.Value)
            {
                _returnValue.Value = true;
                Continue();
            }
            else
            {
                _returnValue.Value = false;
                Continue();
            }
     
        }

        public override string GetSummary()
        {
            if (_target.Value == null)
            {
                return "Error: No Target selected";
            }

            if (_enemy.Value == null)
            {
                return "Error: No Enemy selected";
            }
         
            return  "Is " +_enemy.Value.name.ToString() + " in Range : " + _distance.Value.ToString() ;
        }

        public override Color GetButtonColor()
        {
            return new Color32(96, 191, 156, 255);
        }

        #endregion

        #region Backwards compatibility
       
        #endregion
    }
}