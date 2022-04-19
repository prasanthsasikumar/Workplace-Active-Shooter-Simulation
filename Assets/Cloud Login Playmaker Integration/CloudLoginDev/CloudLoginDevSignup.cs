using UnityEngine;
using CloudLoginUnity;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Enable users to sign up in your Unity game with the following action. They will be saved on your CloudLogin Game.Username is mandatory, but you can also feed in the email parameter if you do not wish to display a seperate display name.")]
	public class CloudLoginDevSignup : FsmStateAction
	{

		[Tooltip("User Email Here.")]
		public FsmString UserEmail;

		[RequiredField]
		[Tooltip("User Username Here")]
		public FsmString UserUsername;

		[RequiredField]
		[Tooltip("User Password Here")]
		public FsmString UserPassword;

		[RequiredField]
		[Tooltip("User Password Here")]
		public FsmString UserPasswordConfirm;

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
			UserUsername = "";
			UserPassword = "";
			UserPasswordConfirm = "";
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{
			var devUserEmail = UserEmail.Value;
			var devUsername = UserUsername.Value;
			var devPassword = UserPassword.Value;
			var devPassword_confirmation = UserPasswordConfirm.Value;

			CloudLogin.SignUp(devUserEmail, devPassword, devPassword_confirmation, devUsername, SignedUp);
			

			void SignedUp(string message, bool hasError)
			{
				if (hasError)
				{
					failMessage.Value = ("Error signign up: " + message);
					Fsm.Event(failureEvent);
				}
				else
				{
					Debug.Log("Signed Up: " + CloudLoginUser.CurrentUser.GetUsername());
					Fsm.Event(successEvent);
				}
				Finish();
			}

		}

		


	}

}
