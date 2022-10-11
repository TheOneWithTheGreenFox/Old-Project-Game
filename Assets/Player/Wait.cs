using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    public GameObject Green;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("time", 82);
    }


    public void time()
    {
        Green.SetActive(true);
    }
}
