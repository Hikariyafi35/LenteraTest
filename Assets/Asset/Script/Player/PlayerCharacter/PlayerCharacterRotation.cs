using UnityEngine;

public class PlayerCharacterRotation : MonoBehaviour
{
    // Reference ke target kamera
    [SerializeField]
    private Transform _cameraTarget;

    // Sensitivity mouse
    [SerializeField]
    private float _lookSensitivity = 0.15f;

    // Kecepatan rotasi character
    [SerializeField]
    private float _rotationSpeed = 10f;

    // Batas rotasi kamera ke atas
    [SerializeField]
    private float _minPitch = -30f;

    // Batas rotasi kamera ke bawah
    [SerializeField]
    private float _maxPitch = 60f;

    // Sudut horizontal kamera
    private float _yaw;

    // Sudut vertical kamera
    private float _pitch;

    // Input movement
    private Vector2 _moveInput;

    public void SetLookInput(Vector2 lookInput)
    {
        // Mouse X digunakan untuk rotasi horizontal kamera
        _yaw += lookInput.x * _lookSensitivity;

        // Mouse Y digunakan untuk rotasi vertical kamera
        _pitch -= lookInput.y * _lookSensitivity;

        // Membatasi pitch kamera
        _pitch = Mathf.Clamp(
            _pitch,
            _minPitch,
            _maxPitch
        );
    }

    public void SetMoveInput(Vector2 moveInput)
    {
        // Menyimpan input movement
        _moveInput = moveInput;
    }

    private void Update()
    {
        RotateCameraTarget();
        RotateCharacter();
    }

    private void RotateCameraTarget()
    {
        // CameraTarget mengikuti posisi player
        _cameraTarget.position =
            transform.position + Vector3.up * 1.5f;

        // CameraTarget bebas berputar
        _cameraTarget.rotation =
            Quaternion.Euler(
                _pitch,
                _yaw,
                0f
            );
    }

    private void RotateCharacter()
    {
        if (_moveInput.sqrMagnitude < 0.01f)
        {
            return;
        }

        // Ambil arah forward kamera
        Vector3 cameraForward =
            _cameraTarget.forward;

        // Hilangkan komponen Y
        cameraForward.y = 0f;

        // Pastikan direction valid
        if (cameraForward.sqrMagnitude < 0.01f)
        {
            return;
        }

        cameraForward.Normalize();

        // Tentukan rotasi character sesuai kamera
        Quaternion targetRotation =
            Quaternion.LookRotation(cameraForward);

        // Rotate character secara smooth
        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                _rotationSpeed * Time.deltaTime
            );
    }
}