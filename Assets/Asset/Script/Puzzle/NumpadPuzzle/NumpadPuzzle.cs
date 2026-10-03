using UnityEngine;

public class NumpadPuzzle : PuzzleBase
{
    // Panel puzzle
    [SerializeField]
    private GameObject _puzzlePanel;

    // Kode yang benar
    [SerializeField]
    private string _correctCode = "153";

    // Maksimal jumlah digit
    [SerializeField]
    private int _maxCodeLength = 3;

    // Kode yang sedang dimasukkan
    private string _currentCode = "";

    public override void Open()
    {
        // Menampilkan puzzle
        _puzzlePanel.SetActive(true);

        // Mengosongkan code
        _currentCode = "";
    }

    public override void Close()
    {
        // Menutup puzzle
        _puzzlePanel.SetActive(false);
    }

    public void EnterNumber(int number)
    {
        // Cegah input jika code sudah penuh
        if (_currentCode.Length >= _maxCodeLength)
        {
            return;
        }

        // Tambahkan angka ke code
        _currentCode += number.ToString();

        Debug.Log("Current Code: " + _currentCode);
    }

    public void ClearCode()
    {
        // Menghapus code
        _currentCode = "";

        Debug.Log("Code Cleared");
    }

    public void SubmitCode()
    {
        // Cek apakah code benar
        if (_currentCode == _correctCode)
        {
            Debug.Log("Correct Code!");

            Complete();
        }
        else
        {
            Debug.Log("Wrong Code!");

            // Reset code
            _currentCode = "";
        }
    }

    protected override void Complete()
    {
        Debug.Log("Numpad Puzzle Complete!");

        // Mengirim event puzzle selesai
        NotifyPuzzleCompleted();
    }
}