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
    public float Speed { get; set; } = 2.0f;
    [field: SerializeField] public Rigidbody2D rigidBody { get; set; }
    float SpeedX;
    #endregion

    #region Local Multiplayer
    #endregion
    private PlayerInput playerInput { get; set; }

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

    public void OnPlayerJoined(PlayerInput playerInput)
    {   //player join on 1
        playerControls.MainMenu.Join1.started += JoinInput;
    }
    /*public bool SwitchCurrentControlScheme(params InputDevice[] devices)
    {

    }*/

    public void JoinInput(InputAction.CallbackContext context)
    {
        Debug.Log("Player has joined");
    }
    /*public void UnjoinInput() 
    {
        playerControls.MainMenu.Join1.started -= JoinInput;
    }*/

    public void MoveInput(InputAction.CallbackContext context)
    {//decided to change movement to just along the x axis
        Vector2 move = context.ReadValue<Vector2>();
        SpeedX = Input.GetAxisRaw("Horizontal") * Speed;
        //SpeedY = Input.GetAxisRaw("Vertical") * Speed;
        rigidBody.velocity = new Vector2(SpeedX, 0);
        
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
