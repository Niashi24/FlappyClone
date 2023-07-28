#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomDrawer&lt;PlayerStateValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(PlayerStateValueList))]
    public class PlayerStateValueListDrawer : AtomDrawer<PlayerStateValueList> { }
}
#endif
