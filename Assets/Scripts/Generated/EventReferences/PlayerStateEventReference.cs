using System;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomEventReference&lt;FiniteStateMachine.Player.PlayerState, PlayerStateVariable, PlayerStateEvent, PlayerStateVariableInstancer, PlayerStateEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class PlayerStateEventReference : AtomEventReference<
        PlayerState,
        PlayerStateVariable,
        PlayerStateEvent,
        PlayerStateVariableInstancer,
        PlayerStateEventInstancer>, IGetEvent 
    { }
}
