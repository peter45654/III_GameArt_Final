// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.Serialization;

namespace Fungus
{
    /// <summary>
    /// Sends a message to either the owner Flowchart or all Flowcharts in the scene. Blocks can listen for this message using a Message Received event handler.
    /// </summary>
    [CommandInfo("Flow", 
                 "Send Message Flowchart", 
                 "Sends a message to a index Flowchart. Blocks can listen for this message using a Message Received event handler.")]
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    public class SendMessageFlowchart : Command
    {
        [Tooltip("Flowchart containing the Block. If none is specified, the parent Flowchart is used.")]
        [SerializeField] protected Flowchart flowchart;

        [Tooltip("Name of the message to send")]
        [SerializeField] protected StringData _message = new StringData("");

        #region Public members

        public override void OnEnter()
        {
            if (flowchart == null)
            {
                Continue();
                return;
            }

            if (_message.Value.Length == 0)
            {
                Continue();
                return;
            }

            flowchart.SendFungusMessage(_message.Value);

            Continue();
        }

        public override string GetSummary()
        {
            if (_message.Value.Length == 0)
            {
                return "Error: No message specified";
            }
            
            return _message.Value;
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }

        #endregion

        #region Backwards compatibility

        [HideInInspector] [FormerlySerializedAs("message")] public string messageOLD = "";

        protected virtual void OnEnable()
        {
            if (messageOLD != "")
            {
                _message.Value = messageOLD;
                messageOLD = "";
            }
        }

        #endregion
    }
}