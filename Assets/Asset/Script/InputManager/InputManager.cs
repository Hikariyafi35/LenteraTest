using UnityEngine;
using UnityEngine.InputSystem;
using static GameInputAction;
using System;

public class InputManager : MonoBehaviour, IPlayerActions
{
    // Reference ke generated input action
    private GameInputAction _gameInputAction;

    // Event untuk mengirim input movement
    public event Action<Vector2> MoveInputChanged;
    public event Action<Vector2> LookInputChanged;
    public event Action InteractPressed;

    private void Awake()
    {
        // Membuat instance generated input action
        _gameInputAction = new GameInputAction();

        // Mendaftarkan callback
        _gameInputAction.Player.SetCallbacks(this);
    }

    private void OnEnable()
    {
        
        _gameInputAction.Player.Enable();
    }

    private void OnDisable()
    {

        _gameInputAction.Player.Disable();
    }
    public void SetPlayerInputEnabled(bool enabled)
    {
        if (enabled)
        {
            _gameInputAction.Player.Enable();
        }
        else
        {
            _gameInputAction.Player.Disable();
        }
    }

    private void OnDestroy()
    {
        // Membersihkan generated input action
        _gameInputAction.Dispose();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Membaca input movement
        Vector2 moveInput = context.ReadValue<Vector2>();
        Debug.Log(moveInput);
        // Mengirim input melalui Action Event
        MoveInputChanged?.Invoke(moveInput);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // Membaca input mouse
        Vector2 lookInput = context.ReadValue<Vector2>();

        // Mengirim input kamera
        LookInputChanged?.Invoke(lookInput);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            InteractPressed?.Invoke();
        }
    }
}