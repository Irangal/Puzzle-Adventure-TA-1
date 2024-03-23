using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playSceneName = "GamePlay1";
    public string informasiSceneName = "InformasiScene";
    public string MainmenuSceneName = "MainMenu";
    public GameObject settingPanel;
    public GameObject back;
    // Fungsi untuk menangani aksi saat tombol "Play" ditekan
    public void PlayGame()
    {
        SceneManager.LoadScene(playSceneName);
    }

    // Fungsi untuk menangani aksi saat tombol "Settings" ditekan
    public void ToggleSettingsPanel()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
    }

    public void kembali()
    {
        SceneManager.LoadScene (MainmenuSceneName);
    }
    // Fungsi untuk menangani aksi saat tombol "Credits" ditekan
    public void Openinformasi()
    {
        SceneManager.LoadScene(informasiSceneName);
    }

    // Fungsi untuk menangani aksi saat tombol "Quit" ditekan
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
