using UnityEngine;
using CloudLoginUnity;
using System.Collections.Generic;
using System;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("CloudLoginDev")]
	[Tooltip("Get various pieces of info regarding logged in user.")]
	public class CloudLoginDevGetUserInfo : FsmStateAction
	{
		
		[UIHint(UIHint.Variable)]
		[Tooltip("String of current user name.")]
		public FsmString userName;

		[UIHint(UIHint.Variable)]
		[Tooltip("Bool if signed in.")]
		public FsmBool isSignedIn;

		[UIHint(UIHint.Variable)]
		[Tooltip("Int number of logins.")]
		public FsmInt numberOfLogins;

		[UIHint(UIHint.Variable)]
		[Tooltip("DateTime of last login.")]
		public FsmString lastLogin;

		[UIHint(UIHint.Variable)]
		[Tooltip("Int of Player Score")]
		public FsmInt score;

		[UIHint(UIHint.Variable)]
		[Tooltip("Int of Player Credits.")]
		public FsmInt credits;

		public override void Reset()
		{
			userName = "";
			isSignedIn = false;
			numberOfLogins = 0;
			lastLogin = "";
			score = 0;
			credits = 0;			
		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{
			DateTime date;
			userName.Value = CloudLoginUser.CurrentUser.GetUsername();
			isSignedIn.Value = CloudLoginUser.CurrentUser.IsSignedIn();
			numberOfLogins.Value = CloudLoginUser.CurrentUser.GetNumberOfLogins();
			date = CloudLoginUser.CurrentUser.GetLastLogin();
			lastLogin.Value = date.ToString("MM/dd/yy");
			score.Value = CloudLoginUser.CurrentUser.GetScore();
			credits.Value = CloudLoginUser.CurrentUser.GetCredits();

			Finish();
			

		}

		


	}

}
