using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Save a player attribute.")]
	public class CloudLoginDevGetPlayerAttribute : FsmStateAction
	{
		[RequiredField]
		[Tooltip("String Key for Attribute Type.")]
		public FsmString attributeType;

		[RequiredField]
		[UIHint(UIHint.Variable)]
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
			
			attributeValue.Value = CloudLoginUser.CurrentUser.GetAttributeValue(type);

				Finish();


		}

		


	}

}
