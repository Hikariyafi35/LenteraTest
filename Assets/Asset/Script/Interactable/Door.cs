using UnityEngine;

public class Door : MonoBehaviour
{
    // Reference ke puzzle yang membuka door
    [SerializeField]
    private PuzzleBase _puzzle;

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
        Debug.Log("Door Open!");

        // Nanti logic buka pintu di sini
    }
}
