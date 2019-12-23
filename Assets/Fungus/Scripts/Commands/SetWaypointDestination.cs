// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Fungus
{
    /// <summary>
    /// Set Waypoint Destination on Specified Nav Mesh Agent"
    /// </summary>
    [CommandInfo("NavMeshAgent", 
                 "Set Waypoint Destination",
                 "Set Waypoint Destination on Specified Nav Mesh Agent")]
    [AddComponentMenu("")]
    //[ExecuteInEditMode]
    public class SetWaypointDestination : Command
    {
        public enum pathState { None ,Loop, PingPong };

        [Tooltip("Reference to a NavMeshAgent component in a game object")]
        [SerializeField] protected NavMeshAgentData _navMeshAgent;

        [Tooltip("WayPoint That Follow")]
        [SerializeField] protected WayPointManager _WayPointManager;

        [Tooltip("The Mode of Loop Type")]
        [SerializeField] protected pathState loopState;

        [Tooltip("The Number of Waypoints" )]
        [SerializeField] protected IntegerData _number_destination;

        private bool isMovingForward = true;

        #region Public members

        public override void OnEnter()
        {
            if (_navMeshAgent.Value == null)
            {
                Continue(); 
            }
            if (_WayPointManager == null)
            {
                Continue(); 
            }
            if (_number_destination < 0)
            {
                Continue(); 
            }

            if (loopState == pathState.None)
            {
                if (_WayPointManager.CreatedPaths.Count == 0) return;
                else
                { 
                    _navMeshAgent.Value.destination = _WayPointManager.CreatedPaths[_number_destination].transform.position;
                }
                Continue();
            }

            if (loopState == pathState.Loop)
            {
                if (_WayPointManager.CreatedPaths.Count == 0) return;
                else
                { 
                    _navMeshAgent.Value.destination = _WayPointManager.CreatedPaths[_number_destination].transform.position;
                    _number_destination.Value = (_number_destination.Value + 1) % _WayPointManager.CreatedPaths.Count;
                }
                Continue();
            }
            else if (loopState == pathState.PingPong)
            {
                if (_WayPointManager.CreatedPaths.Count == 0) return;
                else
                {
                    _navMeshAgent.Value.destination = _WayPointManager.CreatedPaths[_number_destination].transform.position;
            
                    if (isMovingForward)
                    {
                        _number_destination.Value = (_number_destination.Value + 1);
                    }
                    else
                    {
                        _number_destination.Value = (_number_destination.Value - 1);
                    }

                    if (_number_destination.Value == _WayPointManager.CreatedPaths.Count)
                    {
                        isMovingForward = false;
                        _number_destination.Value = _WayPointManager.CreatedPaths.Count - 2;
                    }
                    if (_number_destination.Value < 0)
                    {
                        isMovingForward = true;
                        _number_destination.Value = 1;
                    }
                    Continue();
                }

                
            }
               
        }

        public override string GetSummary()
        {
            if (_navMeshAgent.Value == null)
            {
                return "Error: No NavMeshAgent selected";
            }
            if (_WayPointManager == null)
            {
                return "Error: No WayPoint selected";
            }
            if (_number_destination < 0 )
            {
                return "Error: The Number of Waypoints Need >= 0";
            }
            return _navMeshAgent.Value.name .ToString() + " Destination : "+ _number_destination.Value.ToString()+ " of "+ _WayPointManager.name.ToString();
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