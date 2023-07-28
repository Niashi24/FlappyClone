using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.Pool;

public class SpriteNumberDisplay : MonoBehaviour
{
	[SerializeField]
	private SpriteDigits spriteDigits;

	[SerializeField]
	private SpriteRenderer spritePrefab;

	[SerializeField]
	private float textSpacing = 1.0f;

	[SerializeField]
	private AnchorPosition anchorPosition = AnchorPosition.Center;

	private ObjectPool<SpriteRenderer> _spritePool;

	private SpriteRenderer[] _activeDisplays;

	private void Awake()
	{
		_spritePool = spritePrefab.CreateMonoPool(parent: transform);
		_spritePool.Release(spritePrefab);
		_activeDisplays = Array.Empty<SpriteRenderer>();
		SetDisplay(0);
	}

	public void SetDisplay(int number)
	{
		foreach (var display in _activeDisplays)
			_spritePool.Release(display);

		var digits = number.ToDigits();

		_activeDisplays = PlaceSprites(digits.Length);
		for (int i = 0; i < digits.Length; i++)
		{
			_activeDisplays[i].sprite = spriteDigits[digits[i]];
		}
	}

	private SpriteRenderer[] PlaceSprites(int numSprites) =>
		anchorPosition switch
		{
			AnchorPosition.Center => PlaceSpritesCenter(numSprites),
			AnchorPosition.Left => PlaceSpritesLeft(numSprites),
			AnchorPosition.Right => PlaceSpritesRight(numSprites),
			_ => PlaceSpritesCenter(numSprites)
		};

	private SpriteRenderer[] PlaceSpritesCenter(int numSprites)
	{
		var sprites = new SpriteRenderer[numSprites];

		float position = (1 - numSprites) * (textSpacing + spriteDigits.SpriteWidth) / 2;

		for (int i = 0; i < numSprites; i++)
		{
			sprites[i] = _spritePool.Get();
			sprites[i].transform.localPosition = new(position, 0, 0);
			position += spriteDigits.SpriteWidth + textSpacing;
		}

		return sprites;
	}

	private SpriteRenderer[] PlaceSpritesLeft(int numSprites)
	{
		var sprites = new SpriteRenderer[numSprites];

		float position = 0;

		for (int i = 0; i < numSprites; i++)
		{
			sprites[i] = _spritePool.Get();
			sprites[i].transform.localPosition = new(position, 0, 0);
			position += spriteDigits.SpriteWidth + textSpacing;
		}

		return sprites;
	}

	private SpriteRenderer[] PlaceSpritesRight(int numSprites)
	{
		var sprites = new SpriteRenderer[numSprites];

		float position = (1 - numSprites) * (textSpacing + spriteDigits.SpriteWidth);

		for (int i = 0; i < numSprites; i++)
		{
			sprites[i] = _spritePool.Get();
			sprites[i].transform.localPosition = new(position, 0, 0);
			position += spriteDigits.SpriteWidth + textSpacing;
		}

		return sprites;
	}

	public enum AnchorPosition
	{
		Center,
		Left,
		Right
	}
}