using System;
using Player;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Reference of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomReference&lt;FiniteStateMachine.Player.PlayerState, PlayerStatePair, PlayerStateConstant, PlayerStateVariable, PlayerStateEvent, PlayerStatePairEvent, PlayerStatePlayerStateFunction, PlayerStateVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class PlayerStateReference : AtomReference<
        PlayerState,
        PlayerStatePair,
        PlayerStateConstant,
        PlayerStateVariable,
        PlayerStateEvent,
        PlayerStatePairEvent,
        PlayerStatePlayerStateFunction,
        PlayerStateVariableInstancer>, IEquatable<PlayerStateReference>
    {
        public PlayerStateReference() : base() { }
        public PlayerStateReference(PlayerState value) : base(value) { }
        public bool Equals(PlayerStateReference other) { return base.Equals(other); }
        protected override bool ValueEquals(PlayerState other)
        {
            throw new NotImplementedException();
        }
    }
}
