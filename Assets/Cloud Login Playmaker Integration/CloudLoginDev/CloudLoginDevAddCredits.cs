using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Add game store credits.")]
	public class CloudLoginDevAddCredits : FsmStateAction
	{
		[RequiredField]
		[Tooltip("Store item name.")]
		public FsmInt creditsToAdd;

		public override void Reset()
		{
			creditsToAdd = 0;
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{

			int credits = creditsToAdd.Value;

			CloudLoginUser.CurrentUser.AddCredits(credits, AddCreditsCallback);

			void AddCreditsCallback(string message, bool hasError)
			{
				if (hasError)
				{
					Debug.Log("Error adding credits: " + message);
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
