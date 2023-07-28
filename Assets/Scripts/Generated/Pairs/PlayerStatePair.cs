using System;
using Player;
using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;FiniteStateMachine.Player.PlayerState&gt;`. Inherits from `IPair&lt;FiniteStateMachine.Player.PlayerState&gt;`.
    /// </summary>
    [Serializable]
    public struct PlayerStatePair : IPair<PlayerState>
    {
        public PlayerState Item1 { get => _item1; set => _item1 = value; }
        public PlayerState Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private PlayerState _item1;
        [SerializeField]
        private PlayerState _item2;

        public void Deconstruct(out PlayerState item1, out PlayerState item2) { item1 = Item1; item2 = Item2; }
    }
}