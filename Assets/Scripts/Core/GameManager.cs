using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SaturnRPG.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyClone
{
	public class GameManager : MonoSingleton<GameManager>
	{
		public static AsyncEvent<AppState> OnChangeAppState = new();
		public static AsyncEvent<GameState> OnChangeGameState = new();
		public static AsyncEvent<string> OnStartLoadScene = new(), OnEndLoadScene = new();

		public AppState AppState { get; private set; } = AppState.Title;
		public GameState GameState { get; private set; } = GameState.Start;

		private bool _loadingScene = false;

		public async UniTask ChangeAppState(AppState newState)
		{
			if (newState == AppState) return;
			AppState = newState;
			await OnChangeAppState.Invoke(newState);
		}

		public async UniTask ChangeGameState(GameState newState)
		{
			if (newState == GameState) return;
			GameState = newState;
			await OnChangeGameState.Invoke(newState);
		}

		public async UniTask LoadScene(string sceneName)
		{
			if (_loadingScene) return;

			_loadingScene = true;
			await OnStartLoadScene.Invoke(sceneName);
			await SceneManager.LoadSceneAsync(sceneName);
			await OnEndLoadScene.Invoke(sceneName);
			_loadingScene = false;
		}
	}
}
