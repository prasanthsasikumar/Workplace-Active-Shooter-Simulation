using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Add to leaderboard")]
	public class CloudLoginDevAddLeaderboardEntry : FsmStateAction
	{
		[RequiredField]
		[Tooltip("Leaderboard Name")]
		public FsmString leaderboardName;

		[RequiredField]
		[Tooltip("Store item name.")]
		public FsmInt scoreToAdd;

		[CompoundArray("Extra Attributes", "Attribute Name", "Attribute Value")]
		[Tooltip("Leave at 0 if you don't want to add 'Extra Attributes'.")]
		public FsmString[] attributes;
		public FsmString[] values;

		[Tooltip("Send this event if the connected successfully.")]
		public FsmEvent successEvent;

		[Tooltip("Send this event if unable to connect.")]
		public FsmEvent failureEvent;

		[UIHint(UIHint.Variable)]
		[Tooltip("Outputs error message as string.")]
		public FsmString failMessage;

		public override void Reset()
		{
			scoreToAdd = 0;
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{
			string leaderboard = leaderboardName.Value;
			int score = scoreToAdd.Value;
			var extraAttributes = new Dictionary<string, string>();

			if(attributes.Length != 0)
            {
				for (int i = 0; i < attributes.Length; i++)
                {
					extraAttributes.Add(attributes[i].Value, values[i].Value);
				}
            }

			CloudLoginUser.CurrentUser.AddLeaderboardEntry(leaderboard, score, extraAttributes , SuccessCheck);

			void SuccessCheck(string message, bool hasError)
			{
				if (hasError)
				{
					failMessage.Value = ("Error adding leaderboard entry: " + message);
					Fsm.Event(failureEvent);
				}
				else
				{
					Debug.Log("Leaderboard entered: " + CloudLoginUser.CurrentUser.GetUsername());
					Fsm.Event(successEvent);
				}
				Finish();
			}

		}

		


	}

}
