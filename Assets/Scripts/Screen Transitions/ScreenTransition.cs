using System;
using Cysharp.Threading.Tasks;
using Extensions;
using UnityEngine;

namespace FlappyClone
{
	public class ScreenTransition : MonoBehaviour
	{
		[SerializeField]
		private Animator animator;
		
		[SerializeField]
		private AudioSource audioSource;

		[SerializeField]
		private AudioClip sfxWhooshing;
		
		private void Awake()
		{
			GameManager.OnStartLoadScene.Subscribe(StartLoadTransitionCoroutine);
			GameManager.OnEndLoadScene.Subscribe(FinishLoadTransitionCoroutine);
		}

		private void OnDestroy()
		{
			GameManager.OnStartLoadScene.Unsubscribe(StartLoadTransitionCoroutine);
			GameManager.OnEndLoadScene.Unsubscribe(FinishLoadTransitionCoroutine);
		}

		private UniTask StartLoadTransitionCoroutine(string _)
		{
			audioSource.PlayOneShot(sfxWhooshing);
			return animator.PlayAnimation("Start Load Transition");
		}

		private UniTask FinishLoadTransitionCoroutine(string _)
		{
			return animator.PlayAnimation("Finish Load Transition");
		}
	}
}