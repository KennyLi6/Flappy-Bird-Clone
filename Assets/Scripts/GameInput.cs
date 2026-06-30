using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnJumpAction;
    public event EventHandler OnRestartAction;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Jump.performed += Jump_performed;
        playerInputActions.Player.Restart.performed += Restart_performed;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJumpAction?.Invoke(this, EventArgs.Empty);        
    }

    private void Restart_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnRestartAction?.Invoke(this, EventArgs.Empty);
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }
}
