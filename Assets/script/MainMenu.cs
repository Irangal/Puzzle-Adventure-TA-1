using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string playSceneName = "GamePlay1";
    public string informasiSceneName = "InformasiScene";
    public string MainmenuSceneName = "MainMenu";
    public GameObject settingPanel;
    public GameObject back;

    [System.Serializable]
    public class DataGame
    {
        public string Nama;
        public Sprite Gambar;
        [TextArea(5, 10)] public string Penjelasan;
    }

    //Daftar Hewan
    [Header(" HEWAN DATABASE")]
    public DataGame[] DataHewan;

    public Text namaHewan;
    public Image gambarHewan;
    public Text keteranganHewan;

    //Daftar Tumbuhan
    [Header(" BANGUNAN DATABASE")]
    public DataGame[] DataBangunan;

    public Text namaBangunan;
    public Image gambarBangunan;
    public Text keteranganBangunan;

    public void SpawnHewan(int data)
    {
        namaHewan.text = DataHewan[data - 1].Nama;
        gambarHewan.sprite = DataHewan[data - 1].Gambar;
        keteranganHewan.text = DataHewan[data - 1].Penjelasan;
    }

    public void SpawnBangunan(int data)
    {
        namaBangunan.text = DataBangunan[data - 1].Nama;
        gambarBangunan.sprite = DataBangunan[data - 1].Gambar;
        keteranganBangunan.text = DataBangunan[data - 1].Penjelasan;
    }

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
