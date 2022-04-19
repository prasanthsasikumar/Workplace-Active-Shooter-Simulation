using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Get store item(s) purchased by player as array.")]
	public class CloudLoginDevGetPlayerPurchasedItems : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The Array Variable to use.")]
		public FsmArray array;

		public override void Reset()
		{
			array = null;
		}

		// Code that runs on entering the state.
		public override void OnEnter()
		{
			BuildInventoryArray();
			Finish();

			void BuildInventoryArray()
			{
				foreach (CloudLoginStoreItem storeItem in CloudLoginUser.CurrentUser.GetPurchasedStoreItems())
				{
					string name = storeItem.GetName();
					array.Resize(array.Length + 1);
					array.Set(array.Length - 1, name);
				}

			}

		}

		


	}

}
