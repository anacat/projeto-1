using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    
    private PlayerControls _playerControls;

    private void Awake()
    {
        _playerControls = new PlayerControls();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else if (Instance == null)
        {
            Instance = this;
        }
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

    public Vector2 GetMousePosition()
    {
        return _playerControls.Player.MousePosition.ReadValue<Vector2>();
    }

    public bool PlayerShotInThisFrame()
    {
        return _playerControls.Player.Shoot.triggered;
    }

    public bool SpawnEnemyButton()
    {
        return _playerControls.Player.SpawnEnemy.triggered;
    }
        

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
