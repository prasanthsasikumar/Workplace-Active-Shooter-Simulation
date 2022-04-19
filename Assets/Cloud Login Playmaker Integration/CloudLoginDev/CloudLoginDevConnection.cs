using UnityEngine;
using CloudLoginUnity;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("CloudLoginDev")]
    [Tooltip("Before you can sign in, sign up, or take any other actions, you must connect your Unity game to your CloudLogin Game.")]
    public class CloudLoginDevConnection : FsmStateAction
    {
        [RequiredField]
        [Tooltip("Your Game ID Here.")]
        public FsmString gameID;

        [RequiredField]
        [Tooltip("Your Game Token Here.")]
        public FsmString gameToken;

        [Tooltip("Send this event if the connected successfully.")]
        public FsmEvent successEvent;

        [Tooltip("Send this event if unable to connect.")]
        public FsmEvent failureEvent;

        public override void Reset()
        {
            gameID = "";
            gameToken = "";
            successEvent = null;
            failureEvent = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter()
        {
            CloudLogin.SetVerboseLogging(false);
            var devGameID = gameID.Value;
            var devGameToken = gameToken.Value;
            CloudLogin.SetUpGame(devGameID, devGameToken, GameSetUpCallback);

            void GameSetUpCallback(string message, bool hasError)
            {
                if (hasError)
                {
                    Debug.Log("Error connecting game: " + message);
                    Fsm.Event(failureEvent);
                }
                else
                {
                    Debug.Log("Game Connected Successfully");
                    foreach (CloudLoginStoreItem storeItem in CloudLogin.GetStoreItems())
                    {
                        Debug.Log(storeItem.GetName() + ": " + storeItem.GetCost());
                    }
                    Fsm.Event(successEvent);
                }
                Finish();
            }


        }
    }

}
