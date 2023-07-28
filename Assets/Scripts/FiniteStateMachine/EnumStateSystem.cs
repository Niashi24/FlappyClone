using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FiniteStateMachine
{
	/// <summary>
	/// Uses a dictionary of state (an enum) to state behaviors. Automatically checks if all states are covered.
	/// To use, derive from this with your TState and TComponent, use CreateAssetMenu to create a ScriptableObject,
	/// and attach to a EnumStateMachine of the same type.
	/// </summary>
	/// <typeparam name="TState">The type representing the different states the state machine can take on. Must derive from enum.</typeparam>
	/// <typeparam name="TComponent">The type representing the data the state machine and its behaviors enact upon.</typeparam>
	public class EnumStateSystem<TState, TComponent> : SerializedScriptableObject
		where TState : Enum
	{
		[SerializeField]
		[OnValueChanged(nameof(InitStateBehaviors))]
		[ValidateInput(nameof(ValidateStatesCovered), defaultMessage: "State not covered", InfoMessageType.Warning)]
		private Dictionary<TState, IStateBehavior<TState, TComponent>> stateBehaviors = CreateDefaultDictionary();

		/// <summary>
		/// Gets the state behavior with that state if it exists.
		/// </summary>
		/// <param name="state">The state the state behavior belongs to.</param>
		public IStateBehavior<TState, TComponent> this[TState state] =>
			stateBehaviors.ContainsKey(state) ? stateBehaviors[state] : default;
		
		private void InitStateBehaviors()
		{
			if (stateBehaviors == null)
			{
				stateBehaviors = CreateDefaultDictionary();
				return;
			}

			foreach (TState enumValue in Enum.GetValues(typeof(TState)))
			{
				if (!stateBehaviors.ContainsKey(enumValue))
				{
					stateBehaviors.Add(enumValue, default);
				}
			}
		}

		private bool ValidateStatesCovered()
		{
			foreach (TState enumValue in Enum.GetValues(typeof(TState)))
			{
				if (!stateBehaviors.ContainsKey(enumValue) || stateBehaviors[enumValue] == null)
				{
					return false;
				}
			}

			return true;
		}

		private static Dictionary<TState, IStateBehavior<TState, TComponent>> CreateDefaultDictionary()
		{
			var dict = new Dictionary<TState, IStateBehavior<TState, TComponent>>();
			foreach (TState enumValue in System.Enum.GetValues(typeof(TState)))
				dict.Add(enumValue, default);

			return dict;
		}
	}
}