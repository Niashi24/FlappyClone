using Cysharp.Threading.Tasks;
using FiniteStateMachine;
using FlappyClone;

namespace Player
{
	public class IdlePlayerState : IStateBehavior<PlayerState, PlayerComponent>
	{
		public PlayerState EnterState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component)
		{
			component.animator.SetInteger(PlayerComponent.Activity, 0);
			component.rbdy2D.simulated = false;
			return stateMachine.State;
		}

		public void ExitState(IStateMachine<PlayerState, PlayerComponent> stateMachine, ref PlayerComponent component)
		{
		}

		public PlayerState UpdateState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component)
		{
			if (component.shouldJump)
			{
				GameManager.I.ChangeGameState(GameState.Game).Forget();
				return PlayerState.Game;
			}

			return stateMachine.State;
		}
	}
}