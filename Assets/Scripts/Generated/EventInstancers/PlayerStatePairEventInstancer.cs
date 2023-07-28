using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `PlayerStatePair`. Inherits from `AtomEventInstancer&lt;PlayerStatePair, PlayerStatePairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/PlayerStatePair Event Instancer")]
    public class PlayerStatePairEventInstancer : AtomEventInstancer<PlayerStatePair, PlayerStatePairEvent> { }
}
