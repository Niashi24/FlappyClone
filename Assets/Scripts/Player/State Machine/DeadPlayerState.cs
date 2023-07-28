using Cysharp.Threading.Tasks;
using FiniteStateMachine;
using FlappyClone;

namespace Player
{
	public class DeadPlayerState : IStateBehavior<PlayerState, PlayerComponent>
	{
		public PlayerState EnterState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component)
		{
			component.animator.SetInteger(PlayerComponent.Activity, -1);
			GameManager.I.ChangeGameState(GameState.GameOver).Forget();
			component.transform.eulerAngles = component.transform.eulerAngles.With(z: -90);
			
			return stateMachine.State;
		}

		public void ExitState(IStateMachine<PlayerState, PlayerComponent> stateMachine, ref PlayerComponent component)
		{
		}

		public PlayerState UpdateState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component)
		{
			return stateMachine.State;
		}
	}
}