using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    public MyColour colour;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player.ObjectHeld == null)
        {
            if (colour == MyColour.YELLOW)
            {
                player.SpriteChangeYellow();
            }
            if (colour == MyColour.PURPLE)
            {
                player.SpriteChangePurple();
            }

            player.ObjectHeld = gameObject;
            player.PickUp();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public enum MyColour
{
    GREY,
    YELLOW,
    PURPLE,
    GREEN
}