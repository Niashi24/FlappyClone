using FiniteStateMachine;
using UnityEngine;

namespace Player
{
	public class GamePlayerState : IStateBehavior<PlayerState, PlayerComponent>,
		IPhysics2DBehavior<PlayerState, PlayerComponent>
	{
		public PlayerState EnterState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component)
		{
			component.rbdy2D.simulated = true;
			component.animator.SetInteger(PlayerComponent.Activity, 1);

			if (component.shouldJump) Flap(stateMachine, ref component);

			return stateMachine.State;
		}

		public void ExitState(IStateMachine<PlayerState, PlayerComponent> stateMachine, ref PlayerComponent component)
		{
		}

		public PlayerState UpdateState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component)
		{
			if (component.shouldJump) Flap(stateMachine, ref component);
			PointTowardsVelocity(stateMachine, ref component);
			return stateMachine.State;
		}

		private void PointTowardsVelocity(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component)
		{
			float angle = 0;
			var direction = component.rbdy2D.velocity + Vector2.right * component.groundSpeed.Value;
			if (direction.sqrMagnitude != 0)
			{
				angle = direction.GetAngleOfDirection() * Mathf.Rad2Deg;
				angle = component.angleCurve.Evaluate(angle);
			}

			component.transform.eulerAngles = component.transform.eulerAngles.With(z: angle);
		}

		private void Flap(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component)
		{
			component.shouldJump = false;
			component.audioSource.PlayOneShot(component.flapSFX);
			component.rbdy2D.velocity = Vector2.up * component.jumpVelocity.Value;
		}

		public PlayerState FixedUpdateState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component) =>
			stateMachine.State;

		public PlayerState OnCollisionEnter2DState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component, Collision2D col)
		{
			if (col.gameObject.CompareTag("Obstacle"))
			{
				component.onHitObstacle.Raise();
				return PlayerState.Dead;
			}

			return stateMachine.State;
		}

		public PlayerState OnTriggerEnter2DState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component, Collider2D col)
		{
			if (col.gameObject.CompareTag("Obstacle"))
			{
				component.onHitObstacle.Raise();
				return PlayerState.Falling;
			}
			else if (col.gameObject.CompareTag("Score"))
			{
				component.onPassPipe.Raise();
			}

			return stateMachine.State;
		}
	}
}