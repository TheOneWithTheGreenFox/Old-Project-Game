using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour
{
    public static bool DoorOpen = false;
    public int NumOfAltars;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(DoorOpen == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        OpenDoor.Altars = NumOfAltars;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
