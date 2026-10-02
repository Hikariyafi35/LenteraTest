using System;
using UnityEngine;

public abstract  class PuzzleBase : MonoBehaviour
{
    // Event ketika puzzle selesai
    public event Action PuzzleCompleted;
    // Membuka puzzle
    public abstract void Open();

    // Menutup puzzle
    public abstract void Close();

    // Dipanggil ketika puzzle berhasil diselesaikan
    protected abstract void Complete();

    protected void NotifyPuzzleCompleted()
    {
        // Mengirim event ketika puzzle selesai
        PuzzleCompleted?.Invoke();
    }
}
