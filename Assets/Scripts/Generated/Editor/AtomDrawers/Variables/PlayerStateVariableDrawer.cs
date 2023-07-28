#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomDrawer&lt;PlayerStateVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(PlayerStateVariable))]
    public class PlayerStateVariableDrawer : VariableDrawer<PlayerStateVariable> { }
}
#endif
