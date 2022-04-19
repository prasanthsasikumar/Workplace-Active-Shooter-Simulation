using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Set the game store credits player has.")]
	public class CloudLoginDevSetCredits : FsmStateAction
	{
		[RequiredField]
		[Tooltip("Store item name.")]
		public FsmInt creditsToSet;

		public override void Reset()
		{
			creditsToSet = 0;
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{

			int credits = creditsToSet.Value;

			CloudLoginUser.CurrentUser.SetCredits(credits, SetCreditsCallback);

			void SetCreditsCallback(string message, bool hasError)
			{
				if (hasError)
				{
					Debug.Log("Error setting credits: " + message);
				}
				else
				{
					Debug.Log("After Credits: " + CloudLoginUser.CurrentUser.GetCredits());

				}

				Finish();
			}

		}

		


	}

}
