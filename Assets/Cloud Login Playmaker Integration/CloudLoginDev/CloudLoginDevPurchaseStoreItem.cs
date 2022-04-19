using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Purchase item from in game store.")]
	public class CloudLoginDevPurchaseStoreItem : FsmStateAction
	{
		[RequiredField]
		[Tooltip("Store item ID.")]
		public FsmInt storeItemID;

		[Tooltip("Send this event if purchased successfully.")]
		public FsmEvent successEvent;

		[Tooltip("Send this event if unable to purchase.")]
		public FsmEvent failureEvent;

		public override void Reset()
		{
			storeItemID = 0;
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{
			int itemID = storeItemID.Value;
			CloudLoginUser.CurrentUser.PurchaseStoreItem(itemID, PurchasedItem);
			
			void PurchasedItem(string message, bool hasError)
			{
				if (hasError)
				{
					Debug.Log("Error purchasing item: " + message);
					Fsm.Event(failureEvent);
				}
				else
				{
					Debug.Log("Purchased Item");
					Debug.Log("Current Credits: " + CloudLoginUser.CurrentUser.GetCredits());
					Fsm.Event(successEvent);
				}
			}
			Finish();

				
			

		}

		


	}

}
