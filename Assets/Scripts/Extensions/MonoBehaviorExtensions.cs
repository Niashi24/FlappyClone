using UnityEngine;
using UnityEngine.Pool;

namespace Extensions
{
	public static class MonoBehaviorExtensions
	{
		public static ObjectPool<T> CreateMonoPool<T>(this T prefab, Vector3? position = null,
			Quaternion? rotation = null, Transform parent = null)
			where T : Component
		{
			return new ObjectPool<T>(
				createFunc: () => Object.Instantiate<T>(
					prefab,
					position ?? Vector3.zero,
					rotation ?? Quaternion.identity,
					parent
				),
				actionOnGet: (x) => x.gameObject.SetActive(true),
				actionOnDestroy: (x) => Object.Destroy(x.gameObject),
				actionOnRelease: (x) => x.gameObject.SetActive(false)
			);
		}

		public static ObjectPool<GameObject> CreateGameObjectPool(this GameObject prefab, Vector3? position = null,
			Quaternion? rotation = null, Transform parent = null)
		{
			return new ObjectPool<GameObject>(
				createFunc: () => Object.Instantiate(prefab,
					position ?? Vector3.zero,
					rotation ?? Quaternion.identity,
					parent),
				actionOnGet: x => x.SetActive(true),
				actionOnRelease: x => x.SetActive(false),
				actionOnDestroy: Object.Destroy
			);
		}
	}
}