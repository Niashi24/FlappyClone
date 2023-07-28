using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
	[SerializeField, Required]
	private SpriteRenderer medalImage;

	[SerializeField, Required]
	private GameObject sparkles;

	[SerializeField]
	private ScoreMedal[] scoreToMedal;
	
	[System.Serializable]
	public class ScoreMedal
	{
		public int threshold;
		public Sprite sprite;
	}

	[SerializeField, Required]
	private SpriteNumberDisplay currentScoreDisplay, highScoreDisplay;

	[Header("Move On Screen")]
	[SerializeField]
	private float moveTime = 1f;

	[SerializeField]
	private AnimationCurve moveCurve;

	[SerializeField, Required]
	private Transform startMovePosition, endMovePosition;

	private CancellationTokenSource incrementAsyncSource;

	private Sprite GetSprite(int score)
	{
		for (int i = scoreToMedal.Length - 1; i >= 0; i--)
			if (score >= scoreToMedal[i].threshold)
				return scoreToMedal[i].sprite;

		return null;
	}

	public async UniTask UpdateScorePanel(int score)
	{
		incrementAsyncSource?.Cancel();
		incrementAsyncSource = CancellationTokenSource.CreateLinkedTokenSource(this.GetCancellationTokenOnDestroy());
		var cancelToken = incrementAsyncSource.Token;

		int highScore = PlayerPrefs.GetInt("High Score", 0);

		if (highScore < score)
		{
			highScore = score;
			PlayerPrefs.SetInt("High Score", score);
		}

		currentScoreDisplay.SetDisplay(0);
		highScoreDisplay.SetDisplay(highScore);
		SetMedal(null);

		await MoveOnScreen(cancelToken);
		await IncrementScoreCounterAsync(score, cancelToken);

		SetMedal(GetSprite(score));
	}

	private async UniTask MoveOnScreen(CancellationToken cancelToken)
	{
		float timer = 0f;

		var transform = this.transform;

		while (timer < moveTime)
		{
			transform.position = Vector3.Lerp(startMovePosition.position, endMovePosition.position,
				moveCurve.Evaluate(timer / moveTime));
			timer = Mathf.Min(timer + Time.deltaTime, moveTime);
			await UniTask.Yield(cancelToken);
		}

		transform.position = endMovePosition.position;
	}

	private async UniTask IncrementScoreCounterAsync(int score, CancellationToken cancelToken)
	{
		const float timePerScore = 0.02f;

		float maxTimeForAll = timePerScore * score;

		float timer = 0;
		while (timer < maxTimeForAll)
		{
			int curNum = (int)(timer / maxTimeForAll * score);
			currentScoreDisplay.SetDisplay(curNum);
			timer = Math.Min(timer + Time.deltaTime, maxTimeForAll);
			await UniTask.Yield(cancelToken);
		}

		currentScoreDisplay.SetDisplay(score);
	}

	private void SetMedal(Sprite sprite)
	{
		medalImage.sprite = sprite;
		sparkles.SetActive(sprite != null);
	}
}