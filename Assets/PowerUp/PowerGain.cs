using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGain : MonoBehaviour
{
    public ParticleSystem Break;
    public ParticleSystem GainPower;
    public GameObject player;
    public Rigidbody2D PlayerRb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(Break, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        PlayerMovement Player = collision.gameObject.GetComponent<PlayerMovement>();
        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

        playerRb.gravityScale = 0;
        playerRb.velocity = new Vector2(0, 0);
        Player.transform.position = new Vector3(0, -2.1f, -5);
        Player.interacting = true;

        Instantiate(GainPower, transform.position, Quaternion.identity);
        Invoke("Crystalise", 3.5f);
    }

    private void Crystalise()
    {
        player.GetComponent<PlayerMovement>().SpriteChangeGreenCrystal();
    }
}
