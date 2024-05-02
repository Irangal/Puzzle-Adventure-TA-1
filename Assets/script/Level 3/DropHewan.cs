using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHewan : MonoBehaviour,IDropHandler
{
    public static ChildScript instance;

    [SerializeField] JenisMakanan TipeMakanan;
    public JenisMakanan Makanan { get; set; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Makanan")
        {
            instance = collision.GetComponent<ChildScript>();
        }
        else
        {
            instance = null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {

        if (instance.Makanan == Makanan && instance != null)
        {
            ManagerMakanan.Instance.winCount++;
            //Debug.Log("BETULL!!");
            AudioManager.Instance.PlaySFX("SFX Win");
            ManagerMakanan.Instance.panelWin.SetActive(true);
        }
        else
        {
            ManagerMakanan.Instance.panelLose.SetActive(true);
            AudioManager.Instance.PlaySFX("SFX Lose");
        }


    }

    private void Update()
    {
        TipeMakanan = Makanan;
    }
}
