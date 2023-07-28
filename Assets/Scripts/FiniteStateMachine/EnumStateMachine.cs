using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FiniteStateMachine
{
	/// <summary>
	/// State machine implementing the IStateMachine interface, where TState is an enum.
	/// Uses an EnumStateSystem to generate all enum values to avoid missing a state.
	/// </summary>
	/// <typeparam name="TState">The type representing the different states the state machine can take on. Must derive from enum.</typeparam>
	/// <typeparam name="TComponent">The type representing the data the state machine and its behaviors enact upon.</typeparam>
	public class EnumStateMachine<TState, TComponent> : MonoBehaviour, IStateMachine<TState, TComponent>
		where TState : Enum
	{
		[SerializeField]
		[Required]
		[InlineEditor]
		protected EnumStateSystem<TState, TComponent> stateToBehaviors;

		[field: SerializeField]
		[DisableInPlayMode]
		public TState State { get; protected set; }

		public event Action<TState> OnStateChange;

		[SerializeField]
		protected TComponent component;

		public TComponent Component => component;

		private void Start()
		{
			OnStateChange?.Invoke(State);
			
			var behavior = stateToBehaviors[State];
			if (behavior == null) return;
			

			var state = behavior.EnterState(this, ref component);
			ChangeState(state);
		}

		private void Update()
		{
			var behavior = stateToBehaviors[State];
			if (behavior == null) return;

			var state = behavior.UpdateState(this, ref component);

			ChangeState(state);
		}

		private void FixedUpdate()
		{
			var behavior = stateToBehaviors[State];
			if (behavior is IPhysics2DBehavior<TState, TComponent> physics2DBehavior)
			{
				var state = physics2DBehavior.FixedUpdateState(this, ref component);

				ChangeState(state);
			}
		}

		private void OnCollisionEnter2D(Collision2D col)
		{
			var behavior = stateToBehaviors[State];
			if (behavior is IPhysics2DBehavior<TState, TComponent> physics2DBehavior)
			{
				var state = physics2DBehavior.OnCollisionEnter2DState(this, ref component, col);

				ChangeState(state);
			}
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			var behavior = stateToBehaviors[State];
			if (behavior is IPhysics2DBehavior<TState, TComponent> physics2DBehavior)
			{
				var state = physics2DBehavior.OnTriggerEnter2DState(this, ref component, col);

				ChangeState(state);
			}
		}

		public void ChangeState(TState state)
		{
			while (!state.Equals(State))
			{
				var oldBehavior = stateToBehaviors[State];
				State = state;
				OnStateChange?.Invoke(State);
				// have to call it after changing state so StateMachine in ExitState will have new state
				oldBehavior?.ExitState(this, ref component);
				var behavior = stateToBehaviors[State];
				if (behavior == null) break;

				state = behavior.EnterState(this, ref component);
			}
		}
	}
}