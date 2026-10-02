using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCardPuzzle : PuzzleBase
{
    // Parent tempat kartu dibuat
    [SerializeField]
    private Transform _cardContainer;

    // Prefab kartu
    [SerializeField]
    private MemoryCard _cardPrefab;

    // Semua data kartu
    [SerializeField]
    private List<MemoryCardData> _cardDatas;

    // UI puzzle
    [SerializeField]
    private GameObject _puzzlePanel;

    // Waktu sebelum kartu salah ditutup
    [SerializeField]
    private float _hideDelay = 1f;

    private MemoryCard _firstCard;
    private MemoryCard _secondCard;

    private int _matchedPairs;

    private bool _isChecking;

    public override void Open()
    {
        // Menampilkan puzzle
        _puzzlePanel.SetActive(true);

        // Membuat kartu
        CreateCards();
    }

    public override void Close()
    {
        // Menutup puzzle
        _puzzlePanel.SetActive(false);

        // Menghapus kartu
        ClearCards();
    }

    private void CreateCards()
    {
        // Menghapus kartu lama
        ClearCards();

        // Reset jumlah pasangan
        _matchedPairs = 0;

        // Membuat dua kartu untuk setiap data
        foreach (MemoryCardData data in _cardDatas)
        {
            CreateCard(data);
            CreateCard(data);
        }

        // Mengacak kartu
        ShuffleCards();
    }

    private void CreateCard(MemoryCardData data)
    {
        // Membuat card sebagai child CardGrid
        MemoryCard card =
            Instantiate(
                _cardPrefab,
                _cardContainer
            );

        // Memberikan data ke card
        card.Initialize(
            data,
            this
        );
    }

    public void SelectCard(MemoryCard card)
    {
        // Jangan menerima input ketika sedang mengecek
        if (_isChecking)
        {
            return;
        }

        // Kartu pertama
        if (_firstCard == null)
        {
            _firstCard = card;
            _firstCard.Reveal();

            return;
        }

        // Kartu kedua
        _secondCard = card;
        _secondCard.Reveal();

        // Cek pasangan
        StartCoroutine(CheckCards());
    }

    private IEnumerator CheckCards()
    {
        _isChecking = true;

        // Memberikan waktu pemain melihat kedua kartu
        yield return new WaitForSeconds(_hideDelay);

        // Mengecek apakah pasangan sama
        if (_firstCard.Data == _secondCard.Data)
        {
            _firstCard.SetMatched();
            _secondCard.SetMatched();

            _matchedPairs++;

            // Semua pasangan sudah ditemukan
            if (_matchedPairs >= _cardDatas.Count)
            {
                Complete();
            }
        }
        else
        {
            // Kalau salah, tutup kembali
            _firstCard.Hide();
            _secondCard.Hide();
        }

        // Reset kartu yang dipilih
        _firstCard = null;
        _secondCard = null;

        _isChecking = false;
    }

    protected override void Complete()
    {
        Debug.Log("Memory Puzzle Complete!");

        // Nanti kita sambungkan ke PuzzleManager
    }

    private void ShuffleCards()
    {
        // Mengumpulkan semua card
        List<Transform> cards = new List<Transform>();

        foreach (Transform child in _cardContainer)
        {
            cards.Add(child);
        }

        // Fisher-Yates Shuffle
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            Transform temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }

        // Mengatur ulang urutan card di hierarchy
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].SetSiblingIndex(i);
        }
    }

    private void ClearCards()
    {
        foreach (Transform child in _cardContainer)
        {
            Destroy(child.gameObject);
        }
    }
}