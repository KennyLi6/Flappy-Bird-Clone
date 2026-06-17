using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnJumpAction;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Jump.performed += Jump_performed;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJumpAction?.Invoke(this, EventArgs.Empty);        
    }
}
