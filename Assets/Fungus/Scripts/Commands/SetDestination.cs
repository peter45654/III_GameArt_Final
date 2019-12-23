// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Fungus
{
    /// <summary>
    /// Set Destination to specified Nav Mesh Agent"
    /// </summary>
    [CommandInfo("NavMeshAgent", 
                 "Set Destination",
                 "Set Destination to Specified Nav Mesh Agent")]
    [AddComponentMenu("")]
    //[ExecuteInEditMode]
    public class SetDestination : Command
    {
        [Tooltip("Reference to a NavMeshAgent component in a game object")]
        [SerializeField] protected NavMeshAgentData _navMeshAgent;

        [Tooltip("Destination Position")]
        [SerializeField] protected TransformData _destinationTransform;

        [Tooltip("Destination Position")]
        [SerializeField] protected Vector3Data _destination;

        [Tooltip("Debug Mode")]
        [SerializeField] protected bool _DegbugMode = false;

        #region Public members

        public override void OnEnter()
        {
            if (_navMeshAgent.Value != null)
            {
                if (_destinationTransform.Value != null)
                {
                    _navMeshAgent.Value.destination = _destinationTransform.Value.transform.position;
                }
                else
                {
                    _navMeshAgent.Value.destination = _destination;
                }
            
            }
            if (_DegbugMode)
            {
                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                GameObject target = new GameObject("Destination");
                target.AddComponent<WaypointGizmos>();
                //cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                target.transform.position = _destination;
                target.AddComponent(typeof(DestoryObject));
            }

            Continue();
        }

        public override string GetSummary()
        {
            if ( _navMeshAgent.Value == null)
            {
                return "Error: No NavMeshAgent selected";
            }

            return _navMeshAgent.Value.name.ToString() + ": Destination is" + _destination.Value.ToString() ;
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