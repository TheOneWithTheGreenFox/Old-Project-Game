using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private bool delay;
    public float delayTimer = 0;
    public float delayTimerValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (delay)
        {
            if (delayTimer < delayTimerValue)
            {
                delayTimer += Time.deltaTime;
            }
            if (delayTimer >= delayTimerValue)
            {
                delay = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!delay)
        {
            delay = true;
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
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