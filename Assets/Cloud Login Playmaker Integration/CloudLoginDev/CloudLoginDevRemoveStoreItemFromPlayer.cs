using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Remove store item from player.")]
	public class CloudLoginDevRemoveStoreItemFromPlayer : FsmStateAction
	{
		[RequiredField]
		[Tooltip("Store item ID.")]
		public FsmInt ItemID;

		public override void Reset()
		{
			ItemID = 0;
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{
			int itemID = ItemID.Value;
			CloudLoginUser.CurrentUser.RemoveStoreItem(itemID, false, RemovedItem);
			
			void RemovedItem(string message, bool hasError)
			{
				if (hasError)
				{
					Debug.Log("Error removing item: " + message);
				}
				else
				{
					Debug.Log("Removed Item");
					Debug.Log("Current Credits: " + CloudLoginUser.CurrentUser.GetCredits());
				}
			}
			Finish();

				
			

		}

		


	}

}
