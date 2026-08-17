using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public event Action OnJump;
    public event Action OnAttack;
    public event Action OnDash;
    public event Action OnInteract;
    public event Action OnPause;

    public Vector2 Move { get; private set; }


    public static InputReader Instance { get; private set;}


    public PlayerInputActions input;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            input = new PlayerInputActions();
            input.Enable();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnEnable()
    {
        if(Instance != this) return;
        //continuos
        input.Player.Move.performed += OnMovePerformed;
        input.Player.Move.canceled += OnMoveCanceled;

        //buttons


    }
    void OnDisable()
    {
        //continuos
        input.Player.Move.performed -= OnMovePerformed;
        input.Player.Move.canceled -= OnMoveCanceled;;

        //buttons

    }

    //continuos
    private void OnMovePerformed(InputAction.CallbackContext ctx) => Move = ctx.ReadValue<Vector2>();
    private void OnMoveCanceled(InputAction.CallbackContext ctx) => Move = Vector2.zero;


    //buttons
}