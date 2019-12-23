using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fungus
{
    // <summary>
    /// Normalise a vector3, output can be the same as the input
    /// </summary>
    [CommandInfo("Vector3",
                 "Addition",
                 "Add Two Vector3")]
    [AddComponentMenu("")]
    public class Vector3Addition : Command
    {
        [SerializeField]
        protected Vector3Data vec3InA, vec3InB ,vec3Out;

        public override void OnEnter()
        {
            vec3Out.Value = vec3InA.Value + vec3InB.Value;

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
            if (vec3InA.vector3Ref == variable || vec3InB.vector3Ref == variable || vec3Out.vector3Ref == variable)
                return true;

            return false;
        }
    }
}