using System.Collections;
using System.Collections.Generic;
using Player;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private Sprite pausedImage;

	[SerializeField]
	private Sprite unpausedImage;

	[SerializeField]
	private BoolReference paused;

	private void Start()
	{
		SetPaused(false);
	}

	public void TogglePause()
	{
		SetPaused(!paused.Value);
	}

	public void SetPaused(bool paused)
	{
		this.paused.Value = paused;
		image.sprite = this.paused.Value ? pausedImage : unpausedImage;
		Time.timeScale = this.paused.Value ? 0 : 1;
	}

	public void HideOnPlayerState(PlayerState playerState)
	{
		if (playerState is PlayerState.Dead or PlayerState.Falling)
		{
			gameObject.SetActive(false);
		}
		else
		{
			gameObject.SetActive(true);
		}
	}
}