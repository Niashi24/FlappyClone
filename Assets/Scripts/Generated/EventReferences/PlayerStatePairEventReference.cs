using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `PlayerStatePair`. Inherits from `AtomEventReference&lt;PlayerStatePair, PlayerStateVariable, PlayerStatePairEvent, PlayerStateVariableInstancer, PlayerStatePairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class PlayerStatePairEventReference : AtomEventReference<
        PlayerStatePair,
        PlayerStateVariable,
        PlayerStatePairEvent,
        PlayerStateVariableInstancer,
        PlayerStatePairEventInstancer>, IGetEvent 
    { }
}
