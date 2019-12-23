// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using System.Collections;



namespace Fungus
{
    /// <summary>
    /// Get position in scenethat mouse click.
    /// </summary>
    [CommandInfo("NavMeshAgent", 
                 "Mouse Click Position",
                 "Get Position In Scene That Mouse Click.")]
    [AddComponentMenu("")]
    public class MouseClickPosition : Command 
    {
        [Tooltip("Camera to use for the pan. Will use main camera if set to none.")]
        [SerializeField] protected Camera targetCamera; 

        [Tooltip("Return Bool Value to a Variable")]
        [SerializeField] protected Vector3Data _returnValue;



        #region Public members

        public override void OnEnter()
        {
            if (targetCamera == null)
            {
                Continue();
            }

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
           
                RaycastHit hitInfo;
                if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                {
                    _returnValue.Value = hitInfo.point;

                }
                Continue();
            }

            Continue();
        }

        public override string GetSummary()
        {
            if (targetCamera == null)
            {
                return "Error: No Camera selected";
            }
            else
            {
                return "Get the Mouse Position : " + targetCamera.name.ToString();
            }
        }

        public override Color GetButtonColor()
        {
            return new Color32(96, 191, 156, 255);
        }

        #endregion
    }
}