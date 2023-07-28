using System;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Player
{
	[System.Serializable]
	public class PlayerComponent
	{
		public static readonly int Activity = Animator.StringToHash("Activity");
		
		[SerializeField, Required]
		public Rigidbody2D rbdy2D;

		[SerializeField, Required]
		public Transform transform;

		[SerializeField, Required]
		public AudioSource audioSource;

		[SerializeField, Required]
		public AudioClip flapSFX;

		[SerializeField, Required]
		public AudioClip fallSFX;

		[SerializeField, Required]
		public Animator animator;

		[SerializeField, Required]
		public AnimationCurve angleCurve;

		[SerializeField, Required]
		public VoidEvent onPassPipe;

		[SerializeField, Required]
		public VoidEvent onHitObstacle;
		
		[SerializeField]
		public FloatReference jumpVelocity = new FloatReference(150.0f);

		[SerializeField]
		public FloatReference groundSpeed = new FloatReference(67.5f);

		[ShowInInspector, ReadOnly, NonSerialized]
		public bool shouldJump = false;
	}
}