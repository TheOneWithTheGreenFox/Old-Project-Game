using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public static int Altars;
    public AudioClip Portal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Altars == 0)
        {
            Doorway.DoorOpen = true;
            AudioSource.PlayClipAtPoint(Portal, transform.position);
            foreach (Transform child in gameObject.transform)
                Destroy(child.gameObject);
            
        }
    }
}
