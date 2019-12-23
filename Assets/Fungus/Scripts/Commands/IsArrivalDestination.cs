// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Fungus
{
    /// <summary>
    /// Confirm if Agent is arrive at Destination within a certain distance"
    /// </summary>
    [CommandInfo("NavMeshAgent",
                 "Is Arrive Destination",
                 "Confirm if Agent is Arrive at Destination")]
    [AddComponentMenu("")]
    //[ExecuteInEditMode]
    public class IsArrivalDestination : Command
    {
        [Tooltip("Reference to a NavMeshAgent component in a game object")]
        [SerializeField] protected NavMeshAgentData _navMeshAgent;

        [Tooltip("Set a Threshold to Defination Arrive")]
        [SerializeField] protected FloatData _rangeValue ;

        [Tooltip("Return Bool Value to a Variable")]
        [SerializeField] protected BooleanData _returnValue;

        /*
        [SerializeField]
        protected Variable _returnVariable;
        */

        #region Public members

        public override void OnEnter()
        {
            if (_navMeshAgent.Value != null)
            {

                //bool _arrival = (!_navMeshAgent.Value.pathPending) && (_navMeshAgent.Value.remainingDistance < _rangeValue) ;

                //if ((_navMeshAgent.Value.destination != null) && (!_navMeshAgent.Value.pathPending) && (_navMeshAgent.Value.remainingDistance < _rangeValue.Value))
                if ((!_navMeshAgent.Value.pathPending) &&  (_navMeshAgent.Value.remainingDistance < _rangeValue.Value))
                {
                    _returnValue.Value = true;
                }
                else
                {
                    _returnValue.Value = false;
                }

                Continue();
            }
        }

        public override string GetSummary()
        {
            if (_navMeshAgent.Value == null)
            {
                return "Error: No NavMeshAgent selected";
            }

            return "Is " + _navMeshAgent.Value.name + " Arrive Destination";
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