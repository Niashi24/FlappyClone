using UnityEngine;
using System;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomVariable&lt;FiniteStateMachine.Player.PlayerState, PlayerStatePair, PlayerStateEvent, PlayerStatePairEvent, PlayerStatePlayerStateFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/PlayerState", fileName = "PlayerStateVariable")]
    public sealed class PlayerStateVariable : AtomVariable<PlayerState, PlayerStatePair, PlayerStateEvent, PlayerStatePairEvent, PlayerStatePlayerStateFunction>
    {
        protected override bool ValueEquals(PlayerState other)
        {
            return Value == other;
        }
    }
}
