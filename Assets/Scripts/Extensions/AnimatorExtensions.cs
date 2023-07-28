using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Extensions
{
	public static class AnimatorExtensions
	{
		public static async UniTask PlayAnimation(this Animator animator, string animation)
		{
			var stateID = Animator.StringToHash(animation);
			if (!animator.HasState(0, stateID)) return;
			animator.Play(stateID);
			
			float delaySeconds = animator.GetCurrentAnimatorStateInfo(0).length;

			await UniTask.Delay((int)(1000 * delaySeconds));
		}

		public static async UniTask PlayAnimation(this Animator animator, string animation, CancellationToken cancellationToken)
		{
			var stateID = Animator.StringToHash(animation);
			if (!animator.HasState(0, stateID)) return;
			animator.Play(stateID);
			
			float delaySeconds = animator.GetCurrentAnimatorStateInfo(0).length;

			await UniTask.Delay((int)(1000 * delaySeconds),
				cancellationToken: cancellationToken);
		}
	}
}