using UnityEngine;

public class PuzzleInteractable : MonoBehaviour, IInteractable
{
    // Puzzle yang akan dibuka
    [SerializeField]
    private PuzzleBase _puzzle;

    // Reference ke Puzzle Manager
    [SerializeField]
    private PuzzleManager _puzzleManager;

    public void Interact()
    {
        // Membuka puzzle melalui Puzzle Manager
        _puzzleManager.OpenPuzzle(_puzzle);
    }
}
