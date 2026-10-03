using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;
    private PuzzleBase _currentPuzzle;


    public void OpenPuzzle(PuzzleBase puzzle)
    {
        if (_currentPuzzle != null)
        {
            return;
        }
        // Menyimpan puzzle yang sedang aktif
        _currentPuzzle = puzzle;
        // Subscribe ke event puzzle selesai
        _currentPuzzle.PuzzleCompleted += HandlePuzzleCompleted;

        // Mengunci input player
        _inputManager.SetPlayerInputEnabled(false);

        // Membuka puzzle
        _currentPuzzle.Open();
    }
    public void ClosePuzzle()
    {
        if (_currentPuzzle == null)
        {
            return;
        }
            // Unsubscribe dari event puzzle
        _currentPuzzle.PuzzleCompleted -= HandlePuzzleCompleted;
        // Menutup puzzle
        _currentPuzzle.Close();
        
        // Mengaktifkan kembali input player
        _inputManager.SetPlayerInputEnabled(true);

        // Menghapus reference puzzle aktif
        _currentPuzzle = null;
    }
    private void HandlePuzzleCompleted()
    {
        // Menutup puzzle setelah selesai
        ClosePuzzle();
    }
}
