using CloudLoginUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CloudSaveScript : MonoBehaviour
{
    public TextMeshProUGUI hide, run, fight, attempts, success, deaths;

    void Start()
    {
        string gameID = "94";
        string gameToken = "9b0e2285-aedc-4ad4-b057-596f6045996b";
        CloudLogin.SetUpGame(gameID, gameToken, GameSetUpCallback);
    }



    void GameSetUpCallback(string message, bool hasError)
    {
        if (hasError)
        {
            Debug.Log("Error connecting game: " + message);
        }
        else
        {
            Debug.Log("Game Connected Successfully");
            foreach (CloudLoginStoreItem storeItem in CloudLogin.GetStoreItems())
            {
                Debug.Log(storeItem.GetName() + ": " + storeItem.GetCost());
            }
            CloudLogin.SignIn("prasanth.sasikumar.psk@gmail.com", "Calibri8686", SignedIn);
        }
    }

    void SignedIn(string message, bool hasError)
    {
        if (hasError)
        {
            Debug.Log("Error signign up: " + message);
        }
        else
        {
            Debug.Log("Logged In: " + CloudLoginUser.CurrentUser.name);
            Debug.Log("Current Credits: " + CloudLoginUser.CurrentUser.GetCredits());
            GetAttributes();
        }
    }

    void SetAttributeCallback(string message, bool hasError)
    {
        if (hasError)
        {
            Debug.Log("Error setting attribute: " + message);
        }
        else
        {
            Debug.Log(CloudLoginUser.CurrentUser.GetAttributeValue("Hide")); // Prints "5"
        }
    }

    public void UpdateHide()
    {
        int value = int.Parse(CloudLoginUser.CurrentUser.GetAttributeValue("Hide")) + 1;
        CloudLoginUser.CurrentUser.SetAttribute("Hide", value.ToString());
    }

    public void UpdateRun()
    {
        int value = int.Parse(CloudLoginUser.CurrentUser.GetAttributeValue("Run")) + 1;
        CloudLoginUser.CurrentUser.SetAttribute("Run", value.ToString());
    }

    public void UpdateFight()
    {
        int value = int.Parse(CloudLoginUser.CurrentUser.GetAttributeValue("Fight")) + 1;
        CloudLoginUser.CurrentUser.SetAttribute("Fight", value.ToString());
    }

    public void UpdateAttempts()
    {
        int value = int.Parse(CloudLoginUser.CurrentUser.GetAttributeValue("Attempts")) + 1;
        CloudLoginUser.CurrentUser.SetAttribute("Attempts", value.ToString());
    }

    public void UpdateDeaths()
    {
        int value = int.Parse(CloudLoginUser.CurrentUser.GetAttributeValue("Deaths")) + 1;
        CloudLoginUser.CurrentUser.SetAttribute("Deaths", value.ToString());
    }

    public void UpdateSuccess()
    {
        int value = int.Parse(CloudLoginUser.CurrentUser.GetAttributeValue("Sucess")) + 1;
        CloudLoginUser.CurrentUser.SetAttribute("Sucess", value.ToString());
    }

    public void GetAttributes()
    {
        hide.text = "Hide: " + CloudLoginUser.CurrentUser.GetAttributeValue("Hide");
        run.text = "Run: " + CloudLoginUser.CurrentUser.GetAttributeValue("Run");
        fight.text = "Fight: " + CloudLoginUser.CurrentUser.GetAttributeValue("Fight");
        attempts.text = "Attempts: " + CloudLoginUser.CurrentUser.GetAttributeValue("Attempts");
        success.text = "Sucess: " + CloudLoginUser.CurrentUser.GetAttributeValue("Sucess");
        deaths.text = "Deaths: " + CloudLoginUser.CurrentUser.GetAttributeValue("Deaths");
    }

    public void SaveUserData()
    {
        CloudLoginUser.CurrentUser.SetAttribute("UserData"+DateTime.Now, this.GetComponent<RecordPlayerMovement>().movementData);
    }
}
