using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `PlayerStatePair`. Inherits from `AtomEventReferenceListener&lt;PlayerStatePair, PlayerStatePairEvent, PlayerStatePairEventReference, PlayerStatePairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/PlayerStatePair Event Reference Listener")]
    public sealed class PlayerStatePairEventReferenceListener : AtomEventReferenceListener<
        PlayerStatePair,
        PlayerStatePairEvent,
        PlayerStatePairEventReference,
        PlayerStatePairUnityEvent>
    { }
}
