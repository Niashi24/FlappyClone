using Player;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomEventInstancer&lt;FiniteStateMachine.Player.PlayerState, PlayerStateEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/PlayerState Event Instancer")]
    public class PlayerStateEventInstancer : AtomEventInstancer<PlayerState, PlayerStateEvent> { }
}
