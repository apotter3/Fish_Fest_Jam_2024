using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    #region Controls & Movement
    private PlayerControls playerControls { get; set; }
    public float Speed { get; set; } = 1.0f;
    float SpeedX, SpeedY;
    [field: SerializeField] public Rigidbody2D rigidBody { get; set; }
    #endregion

    private void Awake()
    {
        playerControls ??= new PlayerControls();
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        SubscribeInputs();
    }

    private void Update()
    {
        
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        UnsubscribeInputs();
    }

    public void SubscribeInputs()
    {
        playerControls ??= new PlayerControls();
        playerControls.Badminton.Move.performed += MoveInput;
        playerControls.Badminton.Move.canceled += MoveInput;
        playerControls.Badminton.Hit.started += HitInput;
    }


    public void UnsubscribeInputs()
    {
        if (playerControls == null) throw new NullReferenceException();
        playerControls.Badminton.Move.performed -= MoveInput;
        playerControls.Badminton.Hit.started -= HitInput;
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        SpeedX = Input.GetAxisRaw("Horizontal") * Speed;
        SpeedY = Input.GetAxisRaw("Vertical") * Speed;
        rigidBody.velocity = new Vector2(SpeedX, SpeedY);
        
        Debug.Log("Move");
    }

    public void HitInput(InputAction.CallbackContext context)
    {
        Debug.Log("Hit");
    }
}
