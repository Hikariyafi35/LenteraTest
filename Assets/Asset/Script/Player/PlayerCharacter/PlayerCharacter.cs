using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    
    [SerializeField]
    private InputManager _inputManager;

    [SerializeField]
    private PlayerCharacterMovement _movement;

    
    [SerializeField]
    private PlayerCharacterAnimation _animation;

    private void OnEnable()
    {
        // Subscribe ke event 
        _inputManager.MoveInputChanged += _movement.SetMoveInput;
        _inputManager.MoveInputChanged += _animation.SetMoveInput;
    }

    private void OnDisable()
    {
        // Unsubscribe dari event 
        _inputManager.MoveInputChanged -= _movement.SetMoveInput;
        _inputManager.MoveInputChanged -= _animation.SetMoveInput;
    }
}