using Player;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Value List of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomValueList&lt;FiniteStateMachine.Player.PlayerState, PlayerStateEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/PlayerState", fileName = "PlayerStateValueList")]
    public sealed class PlayerStateValueList : AtomValueList<PlayerState, PlayerStateEvent> { }
}
