using FiniteStateMachine;
using UnityEngine;

namespace Player
{
	[CreateAssetMenu(menuName = "Finite State Machine/Player State System")]
	public class PlayerStateSystem : EnumStateSystem<PlayerState, PlayerComponent>
	{
	}
}