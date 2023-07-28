using System;

namespace FiniteStateMachine
{
	/// <summary>
	/// Interface used for a state machine.
	/// </summary>
	/// <typeparam name="TState">The type representing the different states the state machine can take on.</typeparam>
	/// <typeparam name="TComponent">The type representing the data the state machine and its behaviors enact upon.</typeparam>
	public interface IStateMachine<TState, TComponent>
	{
		/// <summary>
		/// The state the state machine is currently in.
		/// </summary>
		TState State { get; }

		/// <summary>
		/// The current data the state machine is enacting upon.
		/// </summary>
		TComponent Component { get; }

		/// <summary>
		/// Change the current state of the state machine from outside the state machine.
		/// Warning: Do not call ChangeState from inside a state behavior. Rather, return the new state in a callback.
		/// </summary>
		/// <param name="state">The new state the state machine will take on.</param>
		void ChangeState(TState state);
		
		/// <summary>
		/// Event is raised when current state changes, after new state is set.
		/// Triggers both when changing state from inside (StateBehavior) and outside (ChangeState).
		/// Also triggers when the machine is first loaded
		/// </summary>
		event Action<TState> OnStateChange;
	}
}