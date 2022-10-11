using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour {

    public MyColour colour;
    public AudioClip Placed;
    public AudioClip Failed;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player.StoredColour == colour)
        {
            AudioSource.PlayClipAtPoint(Placed, transform.position);
            player.SpriteChangeNormal();
            OpenDoor.Altars -= 1;
            foreach (Transform child in gameObject.transform)
                Destroy(child.gameObject);
        }
        if (player.StoredColour != colour)
        {
            if (player.StoredColour != MyColour.GREY)
            {
                AudioSource.PlayClipAtPoint(Failed, transform.position);
                if (player.ObjectHeld != null)
                {
                    player.ObjectHeld.SetActive(true);
                    player.ObjectHeld = null;
                    player.Dying();
                }
                else
                {
                    player.Dying();
                }    
            }
        }
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
    }
}
