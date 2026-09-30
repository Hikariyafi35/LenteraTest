using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    
    [SerializeField]
    private InputManager _inputManager;

    
    [SerializeField]
    private PlayerCharacterMovement _movement;

    private void OnEnable()
    {
        // Subscribe ke event 
        _inputManager.MoveInputChanged += _movement.SetMoveInput;
    }

    private void OnDisable()
    {
        // Unsubscribe dari event 
        _inputManager.MoveInputChanged -= _movement.SetMoveInput;
    }
}