#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomDrawer&lt;PlayerStateEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(PlayerStateEvent))]
    public class PlayerStateEventDrawer : AtomDrawer<PlayerStateEvent> { }
}
#endif
