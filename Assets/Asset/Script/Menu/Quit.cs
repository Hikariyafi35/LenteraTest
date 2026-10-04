using UnityEngine;

public class Quit : MonoBehaviour
{
    public void ExitApplication()
    {
            Debug.Log("Quit Game triggered!");

            // Berfungsi saat game sudah di-build (.exe, .apk, dll)
            Application.Quit();

            // Khusus saat testing di Unity Editor agar Play Mode berhenti
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
