using UnityEngine;
using CloudLoginUnity;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Enable users to sign in. Email and password (not username), will be used to sign in.")]
	public class CloudLoginDevSignin : FsmStateAction
	{
		[RequiredField]
		[Tooltip("User Email Here.")]
		public FsmString UserEmail;

		[RequiredField]
		[Tooltip("User Password Here")]
		public FsmString UserPassword;

		[Tooltip("Send this event if the connected successfully.")]
		public FsmEvent successEvent;

		[Tooltip("Send this event if unable to connect.")]
		public FsmEvent failureEvent;

		[UIHint(UIHint.Variable)]
		[Tooltip("Outputs error message as string.")]
		public FsmString failMessage;

		public override void Reset()
		{
			UserEmail = "";
			UserPassword = "";
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{
			var userEmail = UserEmail.Value;
			var password = UserPassword.Value;

			CloudLogin.SignIn(userEmail, password, SignedIn);
			

			void SignedIn(string message, bool hasError)
			{
				if (hasError)
				{
					failMessage.Value = ("Error signing in: " + message);
					Fsm.Event(failureEvent);
				}
				else
				{
					Debug.Log("Signed In: " + CloudLoginUser.CurrentUser.GetUsername());
					Fsm.Event(successEvent);
				}
				Finish();
			}

		}

		


	}

}
