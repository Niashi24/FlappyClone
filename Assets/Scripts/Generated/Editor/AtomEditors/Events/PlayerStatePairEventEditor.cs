#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `PlayerStatePair`. Inherits from `AtomEventEditor&lt;PlayerStatePair, PlayerStatePairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(PlayerStatePairEvent))]
    public sealed class PlayerStatePairEventEditor : AtomEventEditor<PlayerStatePair, PlayerStatePairEvent> { }
}
#endif
