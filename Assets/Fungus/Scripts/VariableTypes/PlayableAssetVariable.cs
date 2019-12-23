// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Fungus
{
    /// <summary>
    /// Animator variable type.
    /// </summary>
    [VariableInfo("Other", "PlayableAsset")]
    [AddComponentMenu("")]
    [System.Serializable]
    public class PlayableAssetVariable : VariableBase<PlayableAsset>
    {}

    /// <summary>
    /// Container for an Animator variable reference or constant value.
    /// </summary>
    [System.Serializable]
    public struct PlayableAssetData
    {
        [SerializeField]
        [VariableProperty("<Value>", typeof(PlayableAsset))]
        public PlayableAssetVariable PlayableAssetRef;
        
        [SerializeField]
        public PlayableAsset PlayableAssetVal;

        public static implicit operator PlayableAsset(PlayableAssetData PlayableAssetData)
        {
            return PlayableAssetData.Value;
        }

        public PlayableAssetData(PlayableAsset v)
        {
            PlayableAssetVal = v;
            PlayableAssetRef = null;
        }
            
        public PlayableAsset Value
        {
            get { return (PlayableAssetRef == null) ? PlayableAssetVal : PlayableAssetRef.Value; }
            set { if (PlayableAssetRef == null) { PlayableAssetVal = value; } else { PlayableAssetRef.Value = value; } }
        }

        public string GetDescription()
        {
            if (PlayableAssetRef == null)
            {
                return PlayableAssetVal.ToString();
            }
            else
            {
                return PlayableAssetRef.Key;
            }
        }
    }
}