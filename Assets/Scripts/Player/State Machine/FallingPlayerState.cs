using FiniteStateMachine;
using UnityEngine;

namespace Player
{
	public class FallingPlayerState : IStateBehavior<PlayerState, PlayerComponent>,
		IPhysics2DBehavior<PlayerState, PlayerComponent>
	{
		public PlayerState EnterState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component)
		{
			component.audioSource.PlayOneShot(component.fallSFX);
			if (component.rbdy2D.velocity.y > 0)
				component.rbdy2D.velocity = component.rbdy2D.velocity.With(y: 0);

			return stateMachine.State;
		}

		public void ExitState(IStateMachine<PlayerState, PlayerComponent> stateMachine, ref PlayerComponent component)
		{
		}

		public PlayerState UpdateState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component)
		{
			// Start point towards ground
			PointTowardsGround(stateMachine, ref component);

			return stateMachine.State;
		}

		private void PointTowardsGround(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component)
		{
			var eulerAngles = component.transform.eulerAngles;
			float angle = eulerAngles.z;
			if (angle > 90f) angle -= 360f;

			const float angleAcceleration = 90f;

			angle = Mathf.Max(angle - angleAcceleration * Time.deltaTime, -90f);

			eulerAngles = eulerAngles.With(z: angle);
			component.transform.eulerAngles = eulerAngles;
		}

		public PlayerState FixedUpdateState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component)
		{
			return stateMachine.State;
		}

		public PlayerState OnCollisionEnter2DState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component, Collision2D col)
		{
			if (col.gameObject.CompareTag("Obstacle"))
			{
				return PlayerState.Dead;
			}

			return stateMachine.State;
		}

		public PlayerState OnTriggerEnter2DState(IStateMachine<PlayerState, PlayerComponent> stateMachine,
			ref PlayerComponent component, Collider2D col)
		{
			return stateMachine.State;
		}
	}
}