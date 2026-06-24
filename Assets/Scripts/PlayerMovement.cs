using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private float _jumpForce = 5;
    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _gameInput.OnJumpAction += GameInput_OnJumpAction;
    }

    private void GameInput_OnJumpAction(object sender, System.EventArgs e)
    {
        _rb.linearVelocityY = _jumpForce;
    }

    private void OnDisable()
    {
        _gameInput.OnJumpAction -= GameInput_OnJumpAction;
    }
}
