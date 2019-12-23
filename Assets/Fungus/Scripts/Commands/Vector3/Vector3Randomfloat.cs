using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fungus
{
    // <summary>
    /// Normalise a vector3, output can be the same as the input
    /// </summary>
    [CommandInfo("Vector3",
                 "Random float Vector3",
                 "Create a Random float Vector3 in Limit")]
    [AddComponentMenu("")]
    public class Vector3Randomfloat : Command
    {
        [SerializeField]
        protected float vec3Out_X_min, vec3Out_X_max, vec3Out_Y_min, vec3Out_Y_max, vec3Out_Z_min, vec3Out_Z_max;
        [SerializeField]
        protected Vector3Data vec3Out;

        public override void OnEnter()
        {
            vec3Out.Value = new Vector3(Random.Range(vec3Out_X_min, vec3Out_X_max), Random.Range(vec3Out_Y_min, vec3Out_Y_max) , Random.Range(vec3Out_Z_min, vec3Out_Z_max));
            Continue();
        }

        public override string GetSummary()
        {
            if (vec3Out.vector3Ref == null)
                return "";
            else
                return vec3Out.vector3Ref.Key;
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }

        
        public override bool HasReference(Variable variable)
        {
            if ( vec3Out.vector3Ref == variable)
                return true;

            return false;
        }
        
    }
}