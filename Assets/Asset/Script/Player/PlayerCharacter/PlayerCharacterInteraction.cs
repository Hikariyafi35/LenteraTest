using UnityEngine;

public class PlayerCharacterInteraction : MonoBehaviour
{
    // Jarak maksimal interaction
    [SerializeField]
    private float _interactionDistance = 2f;

    // Ukuran box detection
    [SerializeField]
    private Vector3 _boxHalfExtents = new Vector3(
        0.5f,
        0.5f,
        0.5f
    );

    // Layer object yang bisa diinteraksi
    [SerializeField]
    private LayerMask _interactionLayer;

    public void Interact()
    {
        // Posisi awal BoxCast
        Vector3 origin =
            transform.position + Vector3.up * 1f;

        // Mendeteksi object di depan player
        bool hasHit = Physics.BoxCast(
            origin,
            _boxHalfExtents,
            transform.forward,
            out RaycastHit hit,
            transform.rotation,
            _interactionDistance,
            _interactionLayer
        );

        // Tidak ada object
        if (!hasHit)
        {
            return;
        }

        // Mencari interface IInteractable
        IInteractable interactable =
            hit.collider.GetComponentInParent<IInteractable>();

        // Object tidak memiliki IInteractable
        if (interactable == null)
        {
            return;
        }

        // Jalankan interaction
        interactable.Interact();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        // Posisi awal BoxCast
        Vector3 origin =
            transform.position + Vector3.up * 1f;

        // Posisi tengah dari BoxCast
        Vector3 center =
            origin + transform.forward * (_interactionDistance / 2f);

        // Ukuran box
        Vector3 boxSize =
            _boxHalfExtents * 2f;

        // Panjang box sesuai interaction distance
        boxSize.z += _interactionDistance;

        // Mengikuti rotasi player
        Gizmos.matrix = transform.localToWorldMatrix;

        // Posisi box relatif terhadap player
        Vector3 localCenter =
            new Vector3(
                0f,
                1f,
                _interactionDistance / 2f
            );

        Gizmos.DrawWireCube(
            localCenter,
            new Vector3(
                _boxHalfExtents.x * 2f,
                _boxHalfExtents.y * 2f,
                _interactionDistance +
                _boxHalfExtents.z * 2f
            )
        );

        // Reset matrix
        Gizmos.matrix = Matrix4x4.identity;
    }
}
