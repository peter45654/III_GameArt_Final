// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.Playables;

namespace Fungus
{
    /// <summary>
    /// Animator variable type.
    /// </summary>
    [VariableInfo("Other", "PlayableDirector")]
    [AddComponentMenu("")]
    [System.Serializable]
    public class PlayableDirectorVariable : VariableBase<PlayableDirector>
    {}

    /// <summary>
    /// Container for an Animator variable reference or constant value.
    /// </summary>
    [System.Serializable]
    public struct PlayableDirectorData
    {
        [SerializeField]
        [VariableProperty("<Value>", typeof(PlayableDirector))]
        public PlayableDirectorVariable PlayableDirectorRef;
        
        [SerializeField]
        public PlayableDirector PlayableDirectorVal;

        public static implicit operator PlayableDirector(PlayableDirectorData PlayableDirectorData)
        {
            return PlayableDirectorData.Value;
        }

        public PlayableDirectorData(PlayableDirector v)
        {
            PlayableDirectorVal = v;
            PlayableDirectorRef = null;
        }
            
        public PlayableDirector Value
        {
            get { return (PlayableDirectorRef == null) ? PlayableDirectorVal : PlayableDirectorRef.Value; }
            set { if (PlayableDirectorRef == null) { PlayableDirectorVal = value; } else { PlayableDirectorRef.Value = value; } }
        }

        public string GetDescription()
        {
            if (PlayableDirectorRef == null)
            {
                return PlayableDirectorVal.ToString();
            }
            else
            {
                return PlayableDirectorRef.Key;
            }
        }
    }
}