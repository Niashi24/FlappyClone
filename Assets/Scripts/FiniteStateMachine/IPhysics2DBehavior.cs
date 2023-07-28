using UnityEngine;

namespace FiniteStateMachine
{
	/// <summary>
	/// Used with a IStateBehavior to gain access to some Physics2D callbacks.
	/// Must be used with an IStateBehavior of the same type to be used on the state machine.
	/// </summary>
	/// <typeparam name="TState">The type representing the different states the state machine can take on.</typeparam>
	/// <typeparam name="TComponent">The type representing the data the state machine and its behaviors enact upon.</typeparam>
	public interface IPhysics2DBehavior<TState, TComponent>
	{
		TState FixedUpdateState(IStateMachine<TState, TComponent> stateMachine, ref TComponent component);

		TState OnCollisionEnter2DState(IStateMachine<TState, TComponent> stateMachine, ref TComponent component,
			Collision2D col);

		TState OnTriggerEnter2DState(IStateMachine<TState, TComponent> stateMachine, ref TComponent component,
			Collider2D col);
	}
}