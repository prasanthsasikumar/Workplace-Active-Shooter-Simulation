using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Add game store credits.")]
	public class CloudLoginDevSetScore : FsmStateAction
	{
		[RequiredField]
		[Tooltip("Store item name.")]
		public FsmInt scoreToSet;

		public override void Reset()
		{
			scoreToSet = 0;
		}



		// Code that runs on entering the state.
		public override void OnEnter()
		{

			int score = scoreToSet.Value;

			CloudLoginUser.CurrentUser.SetScore(score, SetScoreCallback);

			void SetScoreCallback(string message, bool hasError)
			{
				if (hasError)
				{
					Debug.Log("Error setting score: " + message);
				}
				else
				{
					Debug.Log("After Score: " + CloudLoginUser.CurrentUser.GetScore());

				}

				Finish();
			}

		}

		


	}

}
