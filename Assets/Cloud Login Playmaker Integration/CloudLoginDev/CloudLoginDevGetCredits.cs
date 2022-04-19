using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Get player's credit count.")]
	public class CloudLoginDevGetCredits : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the integer in an Int Variable.")]
		public FsmInt credits;

		public override void Reset()
		{
			credits = 0;
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{

			credits.Value = CloudLoginUser.CurrentUser.GetCredits();
			Finish();


		}

		


	}

}
