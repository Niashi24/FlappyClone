using System.Threading;
using Cysharp.Threading.Tasks;
using Player;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace FlappyClone
{
	public class GameOverSequencer : MonoBehaviour
	{
		[SerializeField, Required, Header("Score Panel")]
		private ScorePanel scorePanel;

		[SerializeField]
		private IntReference scoreReference;

		[SerializeField, Required, Header("Game Over Image")]
		private SpriteRenderer gameOverImage;

		[SerializeField, Required]
		private Transform startMovePosition, endMovePosition;

		[SerializeField]
		private float moveTime = 0.25f;

		[SerializeField]
		private AnimationCurve moveCurve;

		[SerializeField]
		private AnimationCurve alphaCurve;

		[SerializeField, Required]
		private AudioSource audioSource;

		[SerializeField, Required]
		private AudioClip whooshClip;

		[SerializeField, Required]
		private GameObject menuButton;

		private CancellationTokenSource _gameOverTokenSource;

		public void PlayerStateChanged(PlayerState playerState)
		{
			if (playerState == PlayerState.Dead)
			{
				GameOverAsync().Forget();
			}
		}

		private async UniTask GameOverAsync()
		{
			_gameOverTokenSource?.Cancel();
			_gameOverTokenSource =
				CancellationTokenSource.CreateLinkedTokenSource(this.GetCancellationTokenOnDestroy());
			var cancelToken = _gameOverTokenSource.Token;

			await UniTask.Delay(500, cancellationToken: cancelToken);
			audioSource.PlayOneShot(whooshClip);
			await FadeInGameOverAsync(cancelToken);
			scorePanel.gameObject.SetActive(true);
			await scorePanel.UpdateScorePanel(scoreReference.Value);
			await UniTask.Delay(500, cancellationToken: cancelToken);

			menuButton.SetActive(true);
		}

		private async UniTask FadeInGameOverAsync(CancellationToken cancelToken)
		{
			float timer = 0f;
			
			gameOverImage.gameObject.SetActive(true);

			var gameOverTransform = gameOverImage.transform;
			cancelToken =
				CancellationTokenSource.CreateLinkedTokenSource(cancelToken,
					gameOverImage.GetCancellationTokenOnDestroy()).Token;

			while (timer < moveTime)
			{
				var t = timer / moveTime;
				gameOverTransform.position = Vector3.Lerp(startMovePosition.position, endMovePosition.position,
					moveCurve.Evaluate(t));
				gameOverImage.color = gameOverImage.color.With(a: alphaCurve.Evaluate(t));
				timer = Mathf.Min(timer + Time.deltaTime, moveTime);
				await UniTask.Yield(cancelToken);
			}

			gameOverTransform.position = Vector3.Lerp(startMovePosition.position, endMovePosition.position,
				moveCurve.Evaluate(1));
			gameOverImage.color = gameOverImage.color.With(a: alphaCurve.Evaluate(1));
		}
	}
}