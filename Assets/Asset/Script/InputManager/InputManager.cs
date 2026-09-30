using UnityEngine;
using UnityEngine.InputSystem;
using static GameInputAction;
using UnityEngine.Events;

public class InputManager : MonoBehaviour, IPlayerActions
{
    private GameInputAction _gameInputAction;
    [SerializeField]
    private UnityEvent<Vector2> _onMove;

    private void Awake()
    {
        _gameInputAction = new GameInputAction();

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

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        _onMove?.Invoke(moveInput);
    }
}
