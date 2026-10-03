using UnityEngine;

public class NumpadButton : MonoBehaviour
{
    // Angka yang dimiliki tombol
    [SerializeField]
    private int _number;

    // Reference ke puzzle
    [SerializeField]
    private NumpadPuzzle _puzzle;

    public void OnClick()
    {
        // Mengirim angka ke puzzle
        _puzzle.EnterNumber(_number);
    }
}
