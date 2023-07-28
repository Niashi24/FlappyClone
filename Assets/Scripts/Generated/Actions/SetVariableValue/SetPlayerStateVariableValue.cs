using Player;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Set variable value Action of type `FiniteStateMachine.Player.PlayerState`. Inherits from `SetVariableValue&lt;FiniteStateMachine.Player.PlayerState, PlayerStatePair, PlayerStateVariable, PlayerStateConstant, PlayerStateReference, PlayerStateEvent, PlayerStatePairEvent, PlayerStateVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/PlayerState", fileName = "SetPlayerStateVariableValue")]
    public sealed class SetPlayerStateVariableValue : SetVariableValue<
        PlayerState,
        PlayerStatePair,
        PlayerStateVariable,
        PlayerStateConstant,
        PlayerStateReference,
        PlayerStateEvent,
        PlayerStatePairEvent,
        PlayerStatePlayerStateFunction,
        PlayerStateVariableInstancer>
    { }
}
