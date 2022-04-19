using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Get player's credit count.")]
	public class CloudLoginDevGetScore : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the integer in an Int Variable.")]
		public FsmInt score;

		public override void Reset()
		{
			score = 0;
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{

			score.Value = CloudLoginUser.CurrentUser.GetScore();
			Finish();


		}

		


	}

}
