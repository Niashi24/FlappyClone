using Player;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomEventReferenceListener&lt;FiniteStateMachine.Player.PlayerState, PlayerStateEvent, PlayerStateEventReference, PlayerStateUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/PlayerState Event Reference Listener")]
    public sealed class PlayerStateEventReferenceListener : AtomEventReferenceListener<
        PlayerState,
        PlayerStateEvent,
        PlayerStateEventReference,
        PlayerStateUnityEvent>
    { }
}
