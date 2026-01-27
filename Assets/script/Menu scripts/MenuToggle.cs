using UnityEngine;
using UnityEngine.InputSystem;

public class MenuToggle : MonoBehaviour
{
    [Header("Açılıp kapanacak Pause Menü Paneli")]
    public GameObject pauseMenuPanel;

    [Header("Menü açıkken kapanacak scriptler (ThirdPersonController, StarterAssetsInputs)")]
    public MonoBehaviour[] disableWhenMenuOpen;

    private bool isOpen = false;

    void Start()
    {
        // Oyun başlarken menü kapalı
        if (pauseMenuPanel != null)
            pauseMenuPanel.SetActive(false);

        // Oyun başlarken oyun devam etsin
        Time.timeScale = 1f;

        // Oyun başlarken cursor kilitli (istersen görünür yapabilirsin)
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // ✅ ESC ile menü aç/kapa (NEW INPUT SYSTEM)
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        SetMenuState(!isOpen);
    }

    public void CloseMenu()
    {
        SetMenuState(false);
    }

    private void SetMenuState(bool open)
    {
        if (pauseMenuPanel == null) return;

        isOpen = open;

        // Panel aç/kapat
        pauseMenuPanel.SetActive(isOpen);

        // Menü açıkken player kontrol scriptlerini kapat
        foreach (var s in disableWhenMenuOpen)
        {
            if (s != null)
                s.enabled = !isOpen;
        }

        // Menü açıkken cursor serbest, kapalıyken kilitli
        Cursor.visible = isOpen;
        Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;

        // ✅ Menü açıkken oyunu durdur, kapalıyken devam ettir
        Time.timeScale = isOpen ? 0f : 1f;
    }

    // 🔥 Starter Assets bazen cursor'u tekrar kilitlediği için menü açıkken zorla serbest bırak
    void LateUpdate()
    {
        if (isOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
