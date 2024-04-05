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
    {//Make sure i'm using action maps properly
        playerControls ??= new PlayerControls();
        playerControls.Badminton.Move.performed += MoveInput;
        playerControls.Badminton.Move.canceled += MoveInput;
        playerControls.Badminton.Hit.started += HitInput;
        playerControls.FishJam.Key1.started += QPressed;
        playerControls.FishJam.Key2.started += WPressed;
        playerControls.FishJam.Key3.started += EPressed;
        playerControls.FishJam.Key4.started += RPressed;
    }


    public void UnsubscribeInputs()
    {
        playerControls ??= new PlayerControls();
        playerControls.Badminton.Move.performed -= MoveInput;
        playerControls.Badminton.Move.canceled += MoveInput;
        playerControls.Badminton.Hit.started -= HitInput;
        playerControls.FishJam.Key1.started -= QPressed;
        playerControls.FishJam.Key2.started -= WPressed;
        playerControls.FishJam.Key3.started -= EPressed;
        playerControls.FishJam.Key4.started -= RPressed;
    }

    /*void SwapActionMap(InputAction.CallbackContext context)
    {
        playerInput.SwitchCurrentActionMap();
    }*/

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
    void QPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Q");
    }
    void WPressed(InputAction.CallbackContext context)
    {
        Debug.Log("W");
    }
    void EPressed(InputAction.CallbackContext context)
    {
        Debug.Log("E");
    }
    void RPressed(InputAction.CallbackContext context)
    {
        Debug.Log("R");
    }
}
