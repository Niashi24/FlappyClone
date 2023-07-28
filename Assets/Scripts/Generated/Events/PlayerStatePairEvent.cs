using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `PlayerStatePair`. Inherits from `AtomEvent&lt;PlayerStatePair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/PlayerStatePair", fileName = "PlayerStatePairEvent")]
    public sealed class PlayerStatePairEvent : AtomEvent<PlayerStatePair>
    {
    }
}
