using UnityEngine;

public abstract  class PuzzleBase : MonoBehaviour
{
    // Membuka puzzle
    public abstract void Open();

    // Menutup puzzle
    public abstract void Close();

    // Dipanggil ketika puzzle berhasil diselesaikan
    protected abstract void Complete();
}
