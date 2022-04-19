using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Save a player attribute.")]
	public class CloudLoginDevRemovePlayerAttribute : FsmStateAction
	{
		[RequiredField]
		[Tooltip("String Key for Attribute Type.")]
		public FsmString attributeType;

		

		public override void Reset()
		{
			attributeType = "";
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{
			string type = attributeType.Value;
			CloudLoginUser.CurrentUser.RemoveAttribute(type, RemoveAttributeCallback);

			void RemoveAttributeCallback(string message, bool hasError)
			{
				if (hasError)
				{
					Debug.Log("Error removing attribute: " + message);
				}
				else
				{
					Debug.Log("Attribute removed.");
				}
			}

				Finish();


		}

		


	}

}
