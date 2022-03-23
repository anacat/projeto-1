using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private PlayerControls _playerControls;
    
    /*Ordem das funções
     
    Awake
    OnEnable
    Start
    FixedUpdate
    Update
    LateUpdate
    OnDisable
    OnDestroy
    */
    
    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    public Vector2 GetPlayerMovement() //gets wasd keystrokes
    {
        return _playerControls.Player.Movement.ReadValue<Vector2>();
    }

    public bool PlayerJumpedInThisFrame() //gets space keystroke
    {
        return _playerControls.Player.Jump.triggered;
    }

    public Vector2 GetPlayerLook() //gets mouse delta 
    {
        return _playerControls.Player.Look.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
