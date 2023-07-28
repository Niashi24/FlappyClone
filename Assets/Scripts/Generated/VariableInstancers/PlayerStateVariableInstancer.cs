using Player;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomVariableInstancer&lt;PlayerStateVariable, PlayerStatePair, FiniteStateMachine.Player.PlayerState, PlayerStateEvent, PlayerStatePairEvent, PlayerStatePlayerStateFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/PlayerState Variable Instancer")]
    public class PlayerStateVariableInstancer : AtomVariableInstancer<
        PlayerStateVariable,
        PlayerStatePair,
        PlayerState,
        PlayerStateEvent,
        PlayerStatePairEvent,
        PlayerStatePlayerStateFunction>
    { }
}
