// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using System.Collections;

namespace Fungus
{
    /// <summary>
    /// EventHandler variable type.
    /// </summary>
    [VariableInfo("Other", "EventHandler")]
    [AddComponentMenu("")]
    [System.Serializable]
    public class EventHandlerVariable : VariableBase<EventHandler>
    {
        public static readonly CompareOperator[] compareOperators = { CompareOperator.Equals, CompareOperator.NotEquals };
        public static readonly SetOperator[] setOperators = { SetOperator.Assign, SetOperator.Add, SetOperator.Subtract };

        public virtual bool Evaluate(CompareOperator compareOperator, EventHandler value)
        {
            bool condition = false;

            switch (compareOperator)
            {
                case CompareOperator.Equals:
                    condition = Value == value;
                    break;
                case CompareOperator.NotEquals:
                    condition = Value != value;
                    break;
                default:
                    Debug.LogError("The " + compareOperator.ToString() + " comparison operator is not valid.");
                    break;
            }

            return condition;
        }

        public override void Apply(SetOperator setOperator, EventHandler value)
        {
            switch (setOperator)
            {
                case SetOperator.Assign:
                    Value = value;
                    break;
                default:
                    Debug.LogError("The " + setOperator.ToString() + " set operator is not valid.");
                    break;
            }
        }
    }

    /// <summary>
    /// Container for a EventHandler variable reference or constant value.
    /// </summary>
    [System.Serializable]
    public struct EventHandlerData
    {
        [SerializeField]
        [VariableProperty("<Value>", typeof(EventHandlerVariable))]
        public EventHandlerVariable EventHandlerRef;
        
        [SerializeField]
        public EventHandler EventHandlerVal;

        public EventHandlerData(EventHandler v)
        {
            EventHandlerVal = v;
            EventHandlerRef = null;
        }
        
        public static implicit operator EventHandler(EventHandlerData EventHandlerData)
        {
            return EventHandlerData.Value;
        }

        public EventHandler Value
        {
            get { return (EventHandlerRef == null) ? EventHandlerVal : EventHandlerRef.Value; }
            set { if (EventHandlerRef == null) { EventHandlerVal = value; } else { EventHandlerRef.Value = value; } }
        }

        public string GetDescription()
        {
            if (EventHandlerRef == null)
            {
                return EventHandlerVal.ToString();
            }
            else
            {
                return EventHandlerRef.Key;
            }
        }
    }
}