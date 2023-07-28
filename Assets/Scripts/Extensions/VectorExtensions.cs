using System;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
	public static Color With(this Color original, float? r = null, float? g = null, float? b = null, float? a = null)
	{
		return new Color(
			r ?? original.r,
			g ?? original.g,
			b ?? original.b,
			a ?? original.a
		);
	}

	public static Vector3 With(this Vector3 original, float? x = null, float? y = null, float? z = null)
	{
		return new Vector3(
			x ?? original.x,
			y ?? original.y,
			z ?? original.z
		);
	}

	public static Vector3 Round(this Vector3 original)
	{
		return new Vector3(
			Mathf.Round(original.x),
			Mathf.Round(original.y),
			Mathf.Round(original.z)
		);
	}

	public static Vector3 WithMagnitude(this Vector3 original, float magnitude)
		=> original.normalized * magnitude;

	public static Bounds CalcBounds(this Vector3[] Vertices)
	{
		if (Vertices.Length == 0)
			return new Bounds();

		float minX, minY, maxX, maxY;

		minX = maxX = Vertices[0].x;
		minY = maxY = Vertices[0].y;

		for (int i = 1; i < Vertices.Length; i++)
		{
			if (Vertices[i].x < minX)
				minX = Vertices[i].x;
			if (Vertices[i].y < minY)
				minY = Vertices[i].y;
			if (Vertices[i].x > maxX)
				maxX = Vertices[i].x;
			if (Vertices[i].y > maxY)
				maxY = Vertices[i].y;
		}

		return new Bounds()
		{
			min = new Vector3(minX, minY, 0),
			max = new Vector3(maxX, maxY, 0)
		};
	}

	// Returns the intersection point of the vector lines
	// v = v1 + v2 * t and w = v3 + v4 * u
	public static Vector2 GetIntersectionPoint(Vector2 v1, Vector2 v2, Vector2 v3, Vector2 v4)
	{
		float determinant = v2.x * v4.y - v4.x * v2.y;
		if (determinant == 0) return Vector2.zero;

		// Derived from setting v1 + v2*t = v3 + v4*u
		float t = (v4.x * (v1.y - v3.y) + v4.y * (v3.x - v1.x)) / determinant;

		return v1 + v2 * t;
	}

	public static Vector2 With(this Vector2 original, float? x = null, float? y = null)
	{
		return new Vector2(
			x ?? original.x,
			y ?? original.y
		);
	}

	public static float GetAngleOfDirection(this Vector2 a)
		=> Mathf.Atan2(a.y, a.x);

	public static (float, float) MinMax(this IEnumerable<float> enumerable)
	{
		bool any = false;
		float min = float.MaxValue, max = float.MinValue;
		foreach (float value in enumerable)
		{
			any = true;
			if (value > max) max = value;
			if (value < min) min = value;
		}

		return any ? (min, max) : (0, 0);
	}

	public static float Sign0(this float value)
	{
		if (value == 0) return 0;
		return Mathf.Sign(value);
	}

	public static int[] ToDigits(this int a)
	{
		// Edge case: If the number is 0, return an array with a single element 0.
		if (a == 0)
		{
			return new int[] { 0 };
		}

		// Take the absolute value of the number to handle negative integers.
		int number = Math.Abs(a);

		// Determine the number of digits in the integer.
		int numDigits = 0;
		int tempNumber = number;
		while (tempNumber > 0)
		{
			tempNumber /= 10;
			numDigits++;
		}

		// Create an array with the correct size to store the digits.
		int[] digitsArray = new int[numDigits];

		// Extract the digits and populate the array from left to right.
		for (int i = numDigits - 1; i >= 0; i--)
		{
			digitsArray[i] = number % 10;
			number /= 10;
		}

		return digitsArray;
	}
}