using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Add game store credits.")]
	public class CloudLoginDevAddScore : FsmStateAction
	{
		[RequiredField]
		[Tooltip("Store item name.")]
		public FsmInt scoreToAdd;

		public override void Reset()
		{
			scoreToAdd = 0;
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{

			int score = scoreToAdd.Value;

			CloudLoginUser.CurrentUser.AddScore(score, AddScoreCallback);

			void AddScoreCallback(string message, bool hasError)
			{
				if (hasError)
				{
					Debug.Log("Error adding score: " + message);
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
