using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace FlappyClone.Score
{
	public class ScoreManager : MonoBehaviour
	{
		[SerializeField]
		private IntReference score = new IntReference(0);

		public void IncrementScore()
		{
			score.Value++;
		}

		public void ResetScore()
		{
			score.Value = 0;
		}
	}
}