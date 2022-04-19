using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Save a player attribute.")]
	public class CloudLoginDevSetPlayerAttribute : FsmStateAction
	{
	
		[Tooltip("String Key for Attribute Type.")]
		public FsmString attributeType;

		[Tooltip("String Key for Attribute Value.")]
		public FsmString attributeValue;

		public override void Reset()
		{
			attributeType = "";
			attributeValue = "";
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{
			string type = attributeType.Value;
			string value = attributeValue.Value;
			CloudLoginUser.CurrentUser.SetAttribute(type, value, SetAttributeCallback);

			void SetAttributeCallback(string message, bool hasError)
			{
				if (hasError)
				{
					Debug.Log("Error setting attribute: " + message);
				}
				else
				{
					Debug.Log(CloudLoginUser.CurrentUser.GetAttributeValue(type));
				}
			}

				Finish();


		}

		


	}

}
