using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    public InputSystem_Actions PlayerControl { get; private set; }

    public Action OnJumpStarted;
    public Action OnJumpCanceled;

    private void Awake()
    {
        PlayerControl = new InputSystem_Actions();
        PlayerControl.Player.Jump.started += ctx => OnJumpStarted();
        PlayerControl.Player.Jump.canceled += ctx => OnJumpCanceled();
    }

    private void OnEnable()
    {
        PlayerControl.Enable();
    }

    private void OnDisable()
    {
        DisableControl();
    }

    public void DisableControl()
    {
        PlayerControl.Disable();
    }
}
