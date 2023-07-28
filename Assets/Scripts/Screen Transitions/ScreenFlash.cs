using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
	[SerializeField, Required]
	private Image flashImage;

	[SerializeField]
	private AnimationCurve flashCurve;

	[SerializeField]
	private float flashTime = 0.5f;

	private CancellationTokenSource _flashTokenSource;

	public void StartFlash()
	{
		FlashAsync().Forget();
	}

	private async UniTask FlashAsync()
	{
		_flashTokenSource?.Cancel();
		_flashTokenSource = CancellationTokenSource.CreateLinkedTokenSource(this.GetCancellationTokenOnDestroy());
		var cancelToken = _flashTokenSource.Token;

		float timer = 0;

		while (timer < flashTime)
		{
			flashImage.color = flashImage.color.With(a: flashCurve.Evaluate(timer / flashTime));
			timer = Mathf.Min(timer + Time.deltaTime, flashTime);
			await UniTask.Yield(cancelToken);
		}

		flashImage.color = flashImage.color.With(a: flashCurve.Evaluate(1));
	}
}