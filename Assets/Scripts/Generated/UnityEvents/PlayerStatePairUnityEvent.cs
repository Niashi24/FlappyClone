using System;
using UnityEngine.Events;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// None generic Unity Event of type `PlayerStatePair`. Inherits from `UnityEvent&lt;PlayerStatePair&gt;`.
    /// </summary>
    [Serializable]
    public sealed class PlayerStatePairUnityEvent : UnityEvent<PlayerStatePair> { }
}
