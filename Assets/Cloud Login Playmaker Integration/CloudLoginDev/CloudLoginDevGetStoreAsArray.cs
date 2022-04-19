using UnityEngine;
using CloudLoginUnity;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Get store item(s) name, category, id, description, and cost, as an Array.")]
	public class CloudLoginDevGetStoreAsArray : FsmStateAction
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
			BuildStoreArray();
			Finish();


			void BuildStoreArray()
			{
				foreach (CloudLoginStoreItem storeItem in CloudLogin.GetStoreItems())
				{
					string name = storeItem.GetName();
					array.Resize(array.Length + 1);
					array.Set(array.Length - 1, name);

					string category = storeItem.GetCategory();
					array.Resize(array.Length + 1);
					array.Set(array.Length - 1, category);

					string id = storeItem.GetId().ToString();
					array.Resize(array.Length + 1);
					array.Set(array.Length - 1, id);

					string description = storeItem.GetDescription();
					array.Resize(array.Length + 1);
					array.Set(array.Length - 1, description);

					string cost = storeItem.GetCost().ToString();
					array.Resize(array.Length + 1);
					array.Set(array.Length - 1, cost);
				}

			}

		}

		


	}

}
