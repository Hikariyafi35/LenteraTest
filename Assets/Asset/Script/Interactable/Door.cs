using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Reference ke puzzle yang membuka door
    [SerializeField]
    private PuzzleBase _puzzle;
    [SerializeField]
    private GameObject _ObjectDoor;
    [SerializeField] 
    private Transform _positionOpened;
    [SerializeField] 
    private float _openDuration = 1.5f;
    [SerializeField] 
    private AnimationCurve _movementCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    private Coroutine _moveCoroutine;
    private bool _isOpen = false;
    [SerializeField]
    private GameObject _vfxObject;

    private void Awake()
    {
        // Pastikan VFX dalam kondisi mati di awal permainan
        if (_vfxObject != null)
        {
            _vfxObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        // Subscribe ke event puzzle selesai
        _puzzle.PuzzleCompleted += OpenDoor;
    }

    private void OnDisable()
    {
        // Unsubscribe dari event puzzle selesai
        _puzzle.PuzzleCompleted -= OpenDoor;
    }

    private void OpenDoor()
    {
        // Hindari membuka ulang jika sudah terbuka
        if (_isOpen) return;

        Debug.Log("Door Open!");
        
        if (_positionOpened == null)
        {
            Debug.LogWarning("Open Target belum di-assign di Inspector!", this);
            return;
        }

        // Hentikan coroutine sebelumnya jika sedang berjalan
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }

        _moveCoroutine = StartCoroutine(MoveDoorRoutine(_positionOpened.position));
        
    }
    private IEnumerator MoveDoorRoutine(Vector3 targetPosition)
    {
        _isOpen = true;
        if (_vfxObject != null)
        {
            _vfxObject.SetActive(true);
        }
        Transform doorTransform = _ObjectDoor.transform;
        Vector3 startPosition = doorTransform.position;
        float elapsed = 0f;

        while (elapsed < _openDuration)
        {
            elapsed += Time.deltaTime;
            float percent = Mathf.Clamp01(elapsed / _openDuration);

            // Mengevaluasi kurva easing
            float curveValue = _movementCurve.Evaluate(percent);

            doorTransform.position = Vector3.Lerp(startPosition, targetPosition, curveValue);
            yield return null;
        }

        // Memastikan posisi akhir tepat di target
        doorTransform.position = targetPosition;
        _moveCoroutine = null;
        if (_vfxObject != null)
        {
            _vfxObject.SetActive(false);
        }
    }
}
