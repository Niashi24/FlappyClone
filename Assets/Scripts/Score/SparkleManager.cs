using System;
using Extensions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace FlappyClone.Score
{
	public class SparkleManager : MonoBehaviour
	{
		[SerializeField, Required]
		private SpriteRenderer sparkleSpriteRenderer;

		[SerializeField]
		private float sparkleTime = 0.6f;

		[SerializeField]
		private float sparkleRadius = 11f;

		[SerializeField]
		private AnimationCurve sparkleOverTime;
		
		[SerializeField]
		private Sprite[] sparkles;
		
		private float _timer = 0;

		private void Update()
		{
			_timer = Mathf.Max(0, _timer - Time.deltaTime);

			var t = sparkleOverTime.Evaluate(1 - _timer / sparkleTime);
			sparkleSpriteRenderer.sprite = GetSprite(t);
			
			if (_timer == 0)
			{
				_timer = sparkleTime;
				RandomizePosition();
			}
		}

		private void RandomizePosition()
		{
			sparkleSpriteRenderer.transform.localPosition = ((Vector3)RandomPointOnCircle(sparkleRadius)).Round();
		}

		private Sprite GetSprite(float t)
		{
			if (sparkles.Length == 0) return null;

			int sparkle = Math.Clamp((int)(t * sparkles.Length), 0, sparkles.Length - 1);
			
			return sparkles[sparkle];
		}

		private static Vector2 RandomPointOnCircle(float r)
		{
			// Generate a random angle (in radians) from 0 to 2π (full circle)
			float angle = Random.value * 2 * Mathf.PI;

			// Use the square root of the radius to ensure a uniform distribution of points
			float sqrtR = Mathf.Sqrt(Random.value) * r;

			// Calculate the (x, y) coordinates on the circle using trigonometric functions
			float x = sqrtR * Mathf.Cos(angle);
			float y = sqrtR * Mathf.Sin(angle);

			return new(x, y);
		}

	}
}