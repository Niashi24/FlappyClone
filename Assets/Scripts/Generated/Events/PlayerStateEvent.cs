using Player;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomEvent&lt;FiniteStateMachine.Player.PlayerState&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/PlayerState", fileName = "PlayerStateEvent")]
    public sealed class PlayerStateEvent : AtomEvent<PlayerState>
    {
    }
}
