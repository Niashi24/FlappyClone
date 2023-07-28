#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomDrawer&lt;PlayerStateConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(PlayerStateConstant))]
    public class PlayerStateConstantDrawer : VariableDrawer<PlayerStateConstant> { }
}
#endif
