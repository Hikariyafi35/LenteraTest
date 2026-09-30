using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    // Reference ke Character Controller
    [SerializeField]
    private CharacterController _characterController;

    // Kecepatan gerak player
    [SerializeField]
    private float _moveSpeed = 5f;

    // Gravity
    [SerializeField]
    private float _gravity = -9.81f;

    // Input movement
    private Vector2 _moveInput;

    // Kecepatan vertikal
    private float _verticalVelocity;

    public void SetMoveInput(Vector2 moveInput)
    {
        // Menyimpan input movement
        _moveInput = moveInput;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // Mengubah Vector2 menjadi Vector3
        Vector3 moveDirection = new Vector3(
            _moveInput.x,
            0f,
            _moveInput.y
        );

        // Normalisasi agar diagonal tidak lebih cepat
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        // Gravity
        if (_characterController.isGrounded && _verticalVelocity < 0f)
        {
            _verticalVelocity = -2f;
        }

        _verticalVelocity += _gravity * Time.deltaTime;

        // Movement horizontal
        Vector3 horizontalMovement =
            moveDirection * _moveSpeed;

        // Movement vertical
        Vector3 verticalMovement =
            Vector3.up * _verticalVelocity;

        // Gabungkan movement
        Vector3 finalMovement =
            horizontalMovement + verticalMovement;

        // Gerakkan player
        _characterController.Move(
            finalMovement * Time.deltaTime
        );
    }
}