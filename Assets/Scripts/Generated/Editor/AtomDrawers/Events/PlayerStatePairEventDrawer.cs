#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `PlayerStatePair`. Inherits from `AtomDrawer&lt;PlayerStatePairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(PlayerStatePairEvent))]
    public class PlayerStatePairEventDrawer : AtomDrawer<PlayerStatePairEvent> { }
}
#endif
