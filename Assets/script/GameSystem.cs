using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;
    public Obj_TempatDrop[] Drop_Tempat;
    public OnDrag_Obj[] Obj_Drag;
    public bool SystemAcak;
    public int Target;

    [Header("Win System")]
    public int winCount;
    public Text namaWin;
    public Image gambarWin;
    public Text Penjelasan;

    [Header("Panel Win&Lose")]
    public GameObject panelWin;
    public GameObject panelLose;


    [System.Serializable ]
    public class DataGame
    {
        public string Nama;
        public Sprite Gambar;
        [TextArea(5,10)]public string Penjelasan;
    }
    [Header(" Settingan Default ")]
    public DataGame[] DataPermainan;

    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    int random;
    int random2;

    
    void Start()
    {
        AcakGambar();


    }
    public List<int> AcakSoal = new List<int>();
    public List<int> AcakPosisi  = new List<int>();




    public void AcakGambar ()
    {
        AcakSoal.Clear();
        AcakPosisi.Clear();

        AcakSoal = new List<int>(new int[Obj_Drag.Length]) ;

        for ( int i = 0; i < AcakSoal.Count; i++ )
        {
            random = Random.Range(1, DataPermainan.Length);
            while
                (AcakSoal .Contains ( random)) 
            
                random = Random.Range(1, DataPermainan.Length);
            AcakSoal[i] = random;

            Obj_Drag [i].ID =random - 1;
            Obj_Drag[i].Text.text = DataPermainan [random  - 1].Nama ;

            
        }
        AcakPosisi = new List<int>(new int[Drop_Tempat.Length]);

        for (int i = 0; i < AcakPosisi.Count; i++)
        {
            random2 = Random.Range(1, AcakSoal.Count + 1);
            while
                (AcakPosisi.Contains(random2))
                random2 = Random.Range(1, AcakSoal.Count + 1 );
            AcakPosisi [i] = random2 ;
            Drop_Tempat[i].Drop.ID = AcakSoal [random2 - 1] -1 ;
            Drop_Tempat[i].Gambar.sprite = DataPermainan[Drop_Tempat[i].Drop.ID].Gambar;
            namaWin.text = DataPermainan[Drop_Tempat[i].Drop.ID].Nama;
            gambarWin.sprite = DataPermainan[Drop_Tempat[i].Drop.ID].Gambar;
            Penjelasan.text = DataPermainan[Drop_Tempat[i].Drop.ID].Penjelasan;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            AcakGambar();

    }

    public void NextLevel()
    {
        AcakGambar();
        if (winCount >=4)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
