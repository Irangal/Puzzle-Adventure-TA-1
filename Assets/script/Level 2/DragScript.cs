using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public static DragScript instance;
    [SerializeField] TMPro.TextMeshProUGUI hurufDisplay;

    [SerializeField]private bool petunjuk, terisi;
    private Vector3 posisiAwal;
    private Transform parentAwal;

  

    public string Huruf { get; private set; }

    private void Start()
    {
        
    }

    public void Inisialisasi(Transform parent,string huruf,bool petunjuk)
    {
        Huruf = huruf;
        transform.SetParent(parent);
        hurufDisplay.SetText(Huruf);
        this.petunjuk = petunjuk;
        GetComponent<CanvasGroup>().alpha = petunjuk ? 0.5f : 1f;
        //hurufDisplay.gameObject.SetActive(!petunjuk);
    }

    public void Inisialisasi2(Transform parent, string huruf, bool petunjuk)
    {
        Huruf = huruf;
        transform.SetParent(parent);
        hurufDisplay.SetText(Huruf);
        this.petunjuk = petunjuk;
        GetComponent<CanvasGroup>().alpha = 1f;
        //hurufDisplay.gameObject.SetActive(!petunjuk);
    }


    public void Cocok(Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        petunjuk = true;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (petunjuk)
            return;

        posisiAwal = transform.position;
        parentAwal = transform.parent;
        instance = this;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (petunjuk)
            return;

        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(petunjuk && !terisi)
        {
            if (instance.Huruf == Huruf)
            {
                ManagerKata.Instance.TambahPoint();
                instance.Cocok(transform);
                terisi = true;
                GetComponent<CanvasGroup>().alpha = 1f;
            }
        }

        if (petunjuk)
            return;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (petunjuk)
            return;

        instance = null;

        if(transform.parent == parentAwal)
        {
            transform.position = posisiAwal;
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
