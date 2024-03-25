using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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

    [Header("Panel Win&Lose")]
    public GameObject panelWin;
    public GameObject panelLose;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        SpawnHewan();
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
        //InitKata(DataPermainan[randomData].Nama);
        imageHolder.sprite = DataPermainan[randomData].Gambar;
        imageHolder.GetComponent<DropHewan>().Makanan = DataPermainan[randomData].Makanan;
        //Makanan = DataPermainan[randomData].Makanan;
        //namaWin.text = DataPermainan[randomData].Nama;



    }

}
