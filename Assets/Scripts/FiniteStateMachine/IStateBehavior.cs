namespace FiniteStateMachine
{
	/// <summary>
	/// Represents a state in a state machine
	/// </summary>
	/// <typeparam name="TState">The different states the state machine can take on.</typeparam>
	/// <typeparam name="TComponent">The data the state machine and its behaviors enact upon.</typeparam>
	public interface IStateBehavior<TState, TComponent>
	{
		/// <summary>
		/// Called upon entering the current state (this)
		/// </summary>
		/// <param name="stateMachine">The state machine running the behavior.</param>
		/// <param name="component">The data the state machine and its behaviors enact upon.</param>
		/// <returns>The next state to go to. If the returned state is different from the current state it will go to that state without waiting a frame.</returns>
		TState EnterState(IStateMachine<TState, TComponent> stateMachine, ref TComponent component);

		/// <summary>
		/// Called upon exiting the current state (this)
		/// </summary>
		/// <param name="stateMachine">The state machine running the behavior.</param>
		/// <param name="component">The data the state machine and its behaviors enact upon.</param>
		void ExitState(IStateMachine<TState, TComponent> stateMachine, ref TComponent component);

		/// <summary>
		/// Called on Update from the state machine.
		/// </summary>
		/// <param name="stateMachine">The state machine running the behavior.</param>
		/// <param name="component">The data the state machine and its behaviors enact upon.</param>
		/// <returns>The next state to go to.</returns>
		TState UpdateState(IStateMachine<TState, TComponent> stateMachine, ref TComponent component);
	}
}