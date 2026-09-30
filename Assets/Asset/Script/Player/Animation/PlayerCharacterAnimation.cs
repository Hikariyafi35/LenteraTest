using UnityEngine;

public class PlayerCharacterAnimation : MonoBehaviour
{
    // Reference ke Animator
    [SerializeField]
    private Animator _animator;

    public void SetMoveInput(Vector2 moveInput)
    {
        // Mengirim input horizontal ke Animator
        _animator.SetFloat("MoveX", moveInput.x);

        // Mengirim input vertical ke Animator
        _animator.SetFloat("MoveY", moveInput.y);
    }
}
