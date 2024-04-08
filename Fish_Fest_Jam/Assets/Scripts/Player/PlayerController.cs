using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Controls & Movement
    private PlayerControls PlayerControls { get; set; }
    public float Speed { get; set; } = 1.0f;
    float SpeedX, SpeedY;
    [field: SerializeField] public Rigidbody2D rigidBody { get; set; }
    #endregion

    private void Awake()
    {
        PlayerControls ??= new PlayerControls();
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        PlayerControls.Enable();
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log(this.name + "Moved");

            SpeedX = Input.GetAxisRaw("Horizontal") * Speed;
            SpeedY = Input.GetAxisRaw("Vertical") * Speed;
            rigidBody.velocity = new Vector2(SpeedX, SpeedY);
        }
    }

    public void HitInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log(this.name + "Hit");
        }
    }

    public void PauseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log(this.name + "Paused");
        }
    }
}
