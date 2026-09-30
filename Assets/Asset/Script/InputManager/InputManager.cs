using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour, GameInputAction.IPlayerActions
{
    // Reference ke generated input action
    private GameInputAction _gameInputAction;

    // Event untuk mengirim input movement
    public event Action<Vector2> MoveInputChanged;

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
}