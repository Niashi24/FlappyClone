using System.Collections.Generic;
using Extensions;
using FlappyClone;
using Player;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Pool;

namespace Obstacles
{
	public class PipeManager : MonoBehaviour
	{
		[SerializeField]
		private PlayerStateMachine player;
			
		[SerializeField]
		private GameObject pipePrefab;

		[SerializeField]
		private Transform minSpawnPoint;

		[SerializeField]
		private Transform maxSpawnPoint;

		[SerializeField]
		private FloatReference spawnTimer = new FloatReference(1f);

		[SerializeField]
		private FloatReference groundSpeed = new FloatReference(67.5f);

		private float _timer = 0f;

		private ObjectPool<GameObject> _pipePool;
		private List<GameObject> _activePipes;

		private void Awake()
		{
			_pipePool = pipePrefab.CreateGameObjectPool(parent: transform);
			_activePipes = new();
		}

		private void FixedUpdate()
		{
			if (GameManager.I.GameState != GameState.Game) return;
			if (player.State != PlayerState.Game) return;

			MovePipes();
			SpawnPipes();
		}

		private void MovePipes()
		{
			for (int i = _activePipes.Count - 1; i >= 0; i--)
			{
				_activePipes[i].transform.Translate(Vector3.left * (groundSpeed.Value * Time.deltaTime));

				if (_activePipes[i].transform.position.x < -50f)
				{
					_pipePool.Release(_activePipes[i]);
					_activePipes.RemoveAt(i);
				}
			}
		}

		private void SpawnPipes()
		{
			_timer = Mathf.Max(0f, _timer - Time.deltaTime);

			if (_timer == 0)
			{
				var pipe = _pipePool.Get();

				pipe.transform.position = Vector3.Lerp(minSpawnPoint.position, maxSpawnPoint.position, Random.value).Round();
				_activePipes.Add(pipe);
				
				_timer = spawnTimer.Value;
			}
		}
	}
}