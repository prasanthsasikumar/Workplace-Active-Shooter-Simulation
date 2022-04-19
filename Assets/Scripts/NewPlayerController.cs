using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerController : MonoBehaviour
{
    public InputActionReference button;

    //private void Awake()
    //{
    //    playerControls = new NewControls();
    //}

    private void OnEnable()
    {
        button.action.Enable();
    }

    private void OnDisable()
    {
        button.action.Disable();
    }

    private void Update()
    {
        bool isTriggerPressed = button.action.ReadValue<float>()==1;
        Debug.Log(isTriggerPressed);
    }
}

