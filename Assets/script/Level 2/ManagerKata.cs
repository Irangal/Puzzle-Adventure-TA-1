using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ManagerKata : MonoBehaviour
{
    public static ManagerKata Instance { get; private set; }

    [SerializeField] DragScript hurufPrefab;
    [SerializeField] Transform slotAwal, slotAkhir;
    [SerializeField] Image imageHolder;
  

    [System.Serializable]
    public class DataGame
    {
        public string Nama;
        public Sprite Gambar;
        [TextArea(5, 10)] public string Penjelasan;
    }
    [Header(" Settingan Default ")]
    public DataGame[] DataPermainan;


    

    [Header("Win System")]
    private int poinKata, poin;

    public int winCount;
    public Text namaWin;

    [Header("Panel Win&Lose")]
    public GameObject panelWin;
    public GameObject panelLose;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        SpawnKata();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnKata();

    }

    void SpawnKata()
    {

        int randomData = Random.Range(0, DataPermainan.Length);
        InitKata(DataPermainan[randomData].Nama);
        imageHolder.sprite = DataPermainan[randomData].Gambar;

        namaWin.text = DataPermainan[randomData].Nama;


    }

    void InitKata(string kata)
    {
        foreach (Transform child in slotAwal)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in slotAkhir)
        {
            Destroy(child.gameObject);
        }

        char[] hurufKata = kata.ToCharArray();
        char[] hurufAcak = new char[hurufKata.Length];


        List<char> hurufKataCopy = new List<char>();


        hurufKataCopy = hurufKata.ToList();



        for (int i = 0; i < hurufKata.Length; i++)
        {
            int randomIndex = Random.Range(0, hurufKataCopy.Count);
            hurufAcak[i] = hurufKataCopy[randomIndex];



            hurufKataCopy.RemoveAt(randomIndex);


            DragScript temp = Instantiate(hurufPrefab, slotAwal);

            temp.Inisialisasi(slotAwal, hurufAcak[i].ToString(), false);
        }

        for (int i = 0; i < 3; i++)
        {
            DragScript temp = Instantiate(hurufPrefab, slotAwal);
            temp.Inisialisasi(slotAwal, AcakKata(), false);

            temp.transform.SetSiblingIndex(Random.Range(0, slotAwal.childCount));
            
        }



        for (int i = 0; i < hurufKata.Length; i++)
        {

            DragScript temp = Instantiate(hurufPrefab, slotAkhir);
            temp.Inisialisasi(slotAkhir, hurufKata[i].ToString(), true);

        }


        poinKata = hurufKata.Length;
    }


    public void Shuffle()
    {
        List<int> indexes = new List<int>();
        List<Transform> items = new List<Transform>();
        for (int i = 0; i < transform.childCount; ++i)
        {
            indexes.Add(i);
            items.Add(transform.GetChild(i));
        }

    }


public string AcakKata()
    {
        var allChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var length = 1;

        var randomChars = new char[length];

        for (var i = 0; i < length; i++)
        {
            randomChars[i] = allChars[Random.Range(0, allChars.Length)];
        }

        return new string(randomChars);
    }

    public void TambahPoint()
    {
        poin++;

        if (poin == poinKata)
        {
            Debug.Log("Win");
        }
    }
}
