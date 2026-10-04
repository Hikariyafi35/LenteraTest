using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    [SerializeField] private string _targetSceneName;
    [SerializeField] private string _playerTag = "Player";
    private bool _hasTriggered = false;


    private void OnTriggerEnter(Collider other)
    {
        if (_hasTriggered) return;

        if (other.CompareTag(_playerTag))
        {
            LoadTargetScene();
        }
    }
    private void LoadTargetScene()
    {
        if (string.IsNullOrEmpty(_targetSceneName))
        {
            Debug.LogWarning("Target Scene Name belum diisi!", this);
            return;
        }

        _hasTriggered = true; // Mencegah trigger terpanggil berkali-kali
        SceneManager.LoadScene(_targetSceneName);
    }
}
