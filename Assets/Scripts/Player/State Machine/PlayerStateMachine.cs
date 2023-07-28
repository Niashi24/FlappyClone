using FiniteStateMachine;

namespace Player
{
	public class PlayerStateMachine : EnumStateMachine<PlayerState, PlayerComponent>
	{
		public void Flap()
		{
			component.shouldJump = true;
		}
	}
}