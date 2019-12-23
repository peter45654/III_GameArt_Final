// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Fungus
{
    /// <summary>
    /// "Run away enemy a certain distance"
    /// </summary>
    [CommandInfo("NavMeshAgent", 
                 "Run Away",
                 "Run Away Target a Certain Distance")]
    [AddComponentMenu("")]
    //[ExecuteInEditMode]
    public class RunAway : Command
    {
        [Tooltip("Name of the Source")]
        [SerializeField] protected GameObjectData _source;

        [Tooltip("The Agent of Target")]
        [SerializeField] protected NavMeshAgentData _navMeshAgent;

        [Tooltip("Name of Target")]
        [SerializeField] protected GameObjectData _target;

        #region Public members

        public override void OnEnter()
        {
                                          
            Vector3 disToEnemy = _source.Value.transform.position - _target.Value.transform.position ;
            Vector3 newPos = _source.Value.transform.position + disToEnemy;
            _navMeshAgent.Value.SetDestination(newPos);
            
            Continue();
        }

        public override string GetSummary()
        {
            if (_source.Value == null)
            {
                return "Error: No Target selected";
            }

            if (_navMeshAgent.Value == null)
            {
                return "Error: No NavMeshAgent selected";
            }

            if (_target.Value == null)
            {
                return "Error: No Enemy selected";
            }

            return _source.Value.ToString() + " Run Away " + _target.Value.ToString();
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