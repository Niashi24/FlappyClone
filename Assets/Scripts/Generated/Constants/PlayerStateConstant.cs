using Player;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Constant of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomBaseVariable&lt;FiniteStateMachine.Player.PlayerState&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-teal")]
    [CreateAssetMenu(menuName = "Unity Atoms/Constants/PlayerState", fileName = "PlayerStateConstant")]
    public sealed class PlayerStateConstant : AtomBaseVariable<PlayerState> { }
}
