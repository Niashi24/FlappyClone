#if UNITY_2019_1_OR_NEWER
using Player;
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomEventEditor&lt;FiniteStateMachine.Player.PlayerState, PlayerStateEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(PlayerStateEvent))]
    public sealed class PlayerStateEventEditor : AtomEventEditor<PlayerState, PlayerStateEvent> { }
}
#endif
