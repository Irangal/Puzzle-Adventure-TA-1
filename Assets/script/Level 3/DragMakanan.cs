using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragMakanan : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static ChildScript instance;
    //[SerializeField] TMPro.TextMeshProUGUI hurufDisplay;


    private Vector3 posisiAwal;
    private Transform parentAwal;

    public GameObject child;

    //public static ChildScript instance;
    [SerializeField] JenisMakanan tipeMakanan;
    

    private void Start()
    {
        child.GetComponent<ChildScript>().TipeMakanan = tipeMakanan;
    }

    //public void Inisialisasi(Transform parent, JenisMakanan makanan, bool petunjuk)
    //{
    //    Makanan = makanan;
    //    transform.SetParent(parent);
    //    //hurufDisplay.SetText(Makanan);
    //    this.petunjuk = petunjuk;
    //    //hurufDisplay.gameObject.SetActive(!petunjuk);
    //}

    public void OnBeginDrag(PointerEventData eventData)
    {

        child.SetActive(true);
        posisiAwal = child.transform.position;
        parentAwal = child.transform.parent;
        instance = this.child.GetComponent<ChildScript>();
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {


        child.transform.position = Input.mousePosition;
    }


    public void OnEndDrag(PointerEventData eventData)
    {

        instance = null;

        if (child.transform.parent == parentAwal)
        {
            child.transform.position = posisiAwal;
        }

        child.SetActive(false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
