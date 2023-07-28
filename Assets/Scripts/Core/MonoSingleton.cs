using System;
using UnityEngine;

namespace SaturnRPG.Utilities
{
	public abstract class MonoSingleton<T> : MonoBehaviour
		where T : MonoSingleton<T>
	{
		public static T I { get; private set; }

		private static event Action<T> _onSetSingleton;
		public static event Action<T> OnSetSingleton
		{
			add
			{
				if (I != null)
					value?.Invoke(I);
				_onSetSingleton += value;
			}
			remove => _onSetSingleton -= value;
		}

		private void Awake()
		{
			if (I == null)
			{
				I = this as T;
				_onSetSingleton?.Invoke(I);
			}
			else
			{
				Debug.LogWarning($"Second Instance of {typeof(T)} created. Automatically destroying duplicate.");
				Destroy(gameObject);
			}
		}

		private void OnDestroy()
		{
			if (I == this)
				I = null;
		}
	}
}