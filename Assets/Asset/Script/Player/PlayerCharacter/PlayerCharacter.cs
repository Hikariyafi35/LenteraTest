using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    
    [SerializeField]
    private InputManager _inputManager;

    [SerializeField]
    private PlayerCharacterMovement _movement;


    [SerializeField]
    private PlayerCharacterAnimation _animation;
    [SerializeField]
    private PlayerCharacterRotation _rotation;
    [SerializeField]
    private PlayerCharacterInteraction _interaction;

    private void OnEnable()
    {
        // Subscribe ke event 
        _inputManager.MoveInputChanged += _movement.SetMoveInput;
        _inputManager.MoveInputChanged += _animation.SetMoveInput;
        _inputManager.MoveInputChanged += _rotation.SetMoveInput;
        _inputManager.LookInputChanged += _rotation.SetLookInput;
        _inputManager.InteractPressed += _interaction.Interact;
    }

    private void OnDisable()
    {
        // Unsubscribe dari event 
        _inputManager.MoveInputChanged -= _movement.SetMoveInput;
        _inputManager.MoveInputChanged -= _animation.SetMoveInput;
        _inputManager.MoveInputChanged -= _rotation.SetMoveInput;
        _inputManager.LookInputChanged -= _rotation.SetLookInput;
        _inputManager.InteractPressed -= _interaction.Interact;
    }
}