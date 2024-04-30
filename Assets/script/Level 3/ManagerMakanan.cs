using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public enum JenisMakanan { Daging, Tumbuhan, Segala }
public class ManagerMakanan : MonoBehaviour
{
    public static ManagerMakanan Instance { get; private set; }


    [SerializeField] Image imageHolder;

    

    [System.Serializable]
    public class DataGame
    {
        public string Nama;
        public Sprite Gambar;
        [TextArea(5, 10)] public string Penjelasan;
        public JenisMakanan Makanan;
    }
    [Header(" Settingan Default ")]
    public DataGame[] DataPermainan;


    [Header("Win System")]

    public int winCount;
    public Text namaWin;
    public Image GambarWin;
    public Text Ketarangan;

    [Header("Panel Win&Lose")]
    public GameObject panelWin;
    public GameObject panelLose;
    public GameObject panelFinalWin;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        SpawnHewan();

        
        AudioManager.Instance.x = true;
        if (AudioManager.Instance.x == true)
        {
            AudioManager.Instance.PlayMusic("Gameplay");

            AudioManager.Instance.x = false;
        }
        AudioManager.Instance.PauseSound();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnHewan();

    }

    void SpawnHewan()
    {

        int randomData = Random.Range(0, DataPermainan.Length);

        imageHolder.sprite = DataPermainan[randomData].Gambar;
        imageHolder.GetComponent<DropHewan>().Makanan = DataPermainan[randomData].Makanan;

        //Game Win
        namaWin.text = DataPermainan[randomData].Nama;
        GambarWin.sprite = DataPermainan[randomData].Gambar;
        Ketarangan.text = DataPermainan[randomData].Penjelasan;


    }

    public void NextLevel()
    {
        SpawnHewan();
        if(winCount >= 4)
        {
            panelFinalWin.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void BackMainMenu()
    {
        SceneManager.LoadScene(0);
        //AudioManager.Instance.x = true;
    }

}
