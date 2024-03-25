using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScript : MonoBehaviour
{

    public JenisMakanan TipeMakanan;

    public JenisMakanan Makanan { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        Makanan = TipeMakanan;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
