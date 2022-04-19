using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Gets a single leaderboard for all users.")]
	public class CloudLoginDevGetSingleLeaderboardForAllUsers : FsmStateAction
	{
	

		[RequiredField]
		[Tooltip("Max Number of Entries Pulled")]
		public FsmInt maxEntries;
		
		[RequiredField]
		[Tooltip("Name of leaderboard.")]
		public FsmString leaderboard;


		[RequiredField]
		[Tooltip("Limit One Entry Per User")]
		public FsmBool limitOnePerUser;

		[Tooltip("Send this event if the connected successfully.")]
		public FsmEvent successEvent;

		[Tooltip("Send this event if unable to connect.")]
		public FsmEvent failureEvent;

		[UIHint(UIHint.Variable)]
		[Tooltip("Outputs error message as string.")]
		public FsmString failMessage;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Array to store leaderboard results.")]
		public FsmArray array;


		public override void Reset()
		{
			array = null;
		}

		// Code that runs on entering the state.
		public override void OnEnter()
		{
			
			int entries = maxEntries.Value;
			bool limit = limitOnePerUser.Value;
			string name = leaderboard.Value;

			CloudLogin.Instance.GetLeaderboard(entries, limit, name, LeaderboardRetrieved);
			Finish();

			void LeaderboardRetrieved(string message, bool hasError)
			{
				if (hasError)
				{
					failMessage.Value = ("Error loading leaderboard entries: " + message);
					Fsm.Event(failureEvent);
				}
				else
				{
					
					foreach (CloudLoginLeaderboardEntry entry in CloudLogin.Instance.leaderboardEntries)
					{
						string boardEntry = (entry.GetUsername() + "," + entry.GetScore().ToString() + "," + entry.GetLeaderboardName());
						array.Resize(array.Length + 1);
						array.Set(array.Length - 1, boardEntry);
						foreach (KeyValuePair<string, string> kvPair in entry.GetExtraAttributes())
						{
							
							string pair = (kvPair.Key + ", " + kvPair.Value);
                            string scoreEntry = (array.Get(array.Length - 1) + ", " + pair);
                            array.Set(array.Length - 1, scoreEntry);
                            

                        }

					}
					Fsm.Event(successEvent);


				}

			}

		}


	}

}
