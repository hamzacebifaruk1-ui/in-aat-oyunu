using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Load(int index)
    {
        // Pause menü açıksa oyun durmuş olabilir
        Time.timeScale = 1f;

        // Cursor sahne geçişinde sorun çıkarmasın
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(index);
    }

    // ✅ Menüdeki butonlar
    public void NewGame()
    {
        // Menüden oyuna
        Load(0); // oyun
    }

    public void ContinueGame()
    {
        // Şimdilik NewGame ile aynı (save sistemi yoksa)
        Load(0); // oyun
    }

    public void OpenSettings()
    {
        Load(1); // ayarlar
    }

    public void BackToMenu()
    {
        Load(2); // menu
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
