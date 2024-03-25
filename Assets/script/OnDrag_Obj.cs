using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OnDrag_Obj : MonoBehaviour
{
    public Vector2 SavePosisi;
    public bool isDiAtasObj;
    Transform SaveObj;
    public int ID;
    public Text Text;
    public string playSceneName = "GamePlay1";
    public UnityEvent OnDragBenar;
    // Start is called before the first frame update
    void Start()
    {
        SavePosisi = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
       
    }
    private void OnMouseUp()
    {
        if (isDiAtasObj)
        {
            int ID_TempatDrop = SaveObj.GetComponent<Tempat_Drop>().ID;
            if (ID == ID_TempatDrop)
            {
                //transform.SetParent(SaveObj);
                //transform.localPosition = Vector3.zero;
                //transform.localScale = SaveObj.localScale;

                //SaveObj.GetComponent<SpriteRenderer>().enabled = false;
                //SaveObj.GetComponent<Rigidbody2D >().simulated = false;
                //SaveObj.GetComponent<BoxCollider2D >().enabled = false;
                //gameObject.GetComponent<BoxCollider2D>().enabled = false;

                //OnDragBenar.Invoke ();
                //SceneManager.LoadScene(playSceneName);

                
                GameSystem.instance.winCount += 1;
                transform.position = SavePosisi;
                GameSystem.instance.panelWin.SetActive(true);
            }
            else
            {
                transform.position = SavePosisi;
                GameSystem.instance.panelLose.SetActive(true);
                GameSystem.instance.AcakGambar();
            }
           
        }
        else
        {
            transform.position = SavePosisi;
        }


    }
    private void OnMouseDrag()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }
    private void OnTriggerStay2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Drop"))
        {
            {
                isDiAtasObj = true;
                SaveObj = trig.gameObject.transform;
            }
        }

    }
   private void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Drop"))
        {
            isDiAtasObj = false;
        }
    }
}
