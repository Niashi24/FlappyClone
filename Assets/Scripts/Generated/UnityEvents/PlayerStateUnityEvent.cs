using System;
using Player;
using UnityEngine.Events;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// None generic Unity Event of type `FiniteStateMachine.Player.PlayerState`. Inherits from `UnityEvent&lt;FiniteStateMachine.Player.PlayerState&gt;`.
    /// </summary>
    [Serializable]
    public sealed class PlayerStateUnityEvent : UnityEvent<PlayerState> { }
}
