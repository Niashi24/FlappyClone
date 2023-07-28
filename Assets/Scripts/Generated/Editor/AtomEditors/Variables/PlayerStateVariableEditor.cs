using Player;
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `FiniteStateMachine.Player.PlayerState`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(PlayerStateVariable))]
    public sealed class PlayerStateVariableEditor : AtomVariableEditor<PlayerState, PlayerStatePair> { }
}
