// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.AI;

namespace Fungus
{
    /// <summary>
    /// Animator variable type.
    /// </summary>
    [VariableInfo("Other", "NavMeshAgent")]
    [AddComponentMenu("")]
    [System.Serializable]
    public class NavMeshAgentVariable : VariableBase<NavMeshAgent>
    {}

    /// <summary>
    /// Container for an Animator variable reference or constant value.
    /// </summary>
    [System.Serializable]
    public struct NavMeshAgentData
    {
        [SerializeField]
        [VariableProperty("<Value>", typeof(NavMeshAgent))]
        public NavMeshAgentVariable navMeshAgentRef;
        
        [SerializeField]
        public NavMeshAgent navMeshAgentVal;

        public static implicit operator NavMeshAgent(NavMeshAgentData navMeshAgentData)
        {
            return navMeshAgentData.Value;
        }

        public NavMeshAgentData(NavMeshAgent v)
        {
            navMeshAgentVal = v;
            navMeshAgentRef = null;
        }
            
        public NavMeshAgent Value
        {
            get { return (navMeshAgentRef == null) ? navMeshAgentVal : navMeshAgentRef.Value; }
            set { if (navMeshAgentRef == null) { navMeshAgentVal = value; } else { navMeshAgentRef.Value = value; } }
        }

        public string GetDescription()
        {
            if (navMeshAgentRef == null)
            {
                return navMeshAgentVal.ToString();
            }
            else
            {
                return navMeshAgentRef.Key;
            }
        }
    }
}