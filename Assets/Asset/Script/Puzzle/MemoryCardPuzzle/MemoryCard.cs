using UnityEngine;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour
{
    // Image untuk kartu
    [SerializeField]
    private Image _icon;

    // Image belakang kartu
    [SerializeField]
    private GameObject _cardBack;

    // Data kartu
    private MemoryCardData _data;

    // Reference ke puzzle
    private MemoryCardPuzzle _puzzle;

    private bool _isRevealed;
    private bool _isMatched;

    public MemoryCardData Data => _data;

    public void Initialize(
        MemoryCardData data,
        MemoryCardPuzzle puzzle
    )
    {
        _data = data;
        _puzzle = puzzle;

        // Menampilkan icon kartu
        _icon.sprite = _data.Icon;

        Hide();
    }

    public void OnClick()
    {
        // Jangan melakukan apa-apa kalau
        // kartu sudah terbuka atau matched
        if (_isRevealed || _isMatched)
        {
            return;
        }

        // Beritahu puzzle bahwa kartu dipilih
        _puzzle.SelectCard(this);
    }

    public void Reveal()
    {
        _isRevealed = true;
        _cardBack.SetActive(false);
    }

    public void Hide()
    {
        _isRevealed = false;
        _cardBack.SetActive(true);
    }

    public void SetMatched()
    {
        _isMatched = true;
    }
}
