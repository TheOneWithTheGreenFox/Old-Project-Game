using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Sprites")]
    public MyColour StoredColour = MyColour.GREY;
    public GameObject ObjectHeld = null;
    public Sprite YellowSprite;
    public Sprite PurpleSprite;
    public Sprite GreenCrystal;
    public Sprite NormalSprite;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    public AudioClip Pickedup;

    [Header("Colliders and particles")]
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private BoxCollider2D col;
    [SerializeField]
    private ParticleSystem DeathParticle;
    [SerializeField]
    private ParticleSystem ReviveParticle;

    [Header("Moving")]
    public int FacingDirection;
    public float movement;
    public float moveSpeed;

    [Header("Dashing")]
    public float DashSpeed;
    public float DashSpeedGround;
    public float DashHeight;
    private bool isDashing = false;
    private bool canDash = true;
    private bool canResetDash = false;
    private float dashTimer;
    public float dashTimerValue;

    [Header("Jumping")]
    public float JumpVelocity;
    private float jumpTimer = 0.0f;
    public float maxJumpTime;
    private bool isJumping;

    [Header("Misc")]
    public Vector3 AreaStart;
    private bool isGrounded;
    public LayerMask WhatIsGround;
    public bool interacting;
    public static int Health = 10;

    // Use this for initialization
    void Start()
    {
        Health = 10;
        canDash = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!interacting)
        {
            movement = Input.GetAxis("Horizontal");
            if (!isDashing)
            {
                rigidbody.velocity = new Vector2(movement * moveSpeed, rigidbody.velocity.y);

                if (Input.GetAxis("Dash") > 0 && canDash)
                {
                    isDashing = true;
                    canDash = false;
                    canResetDash = false;
                    //Debug.Log("Dash");
                    if (isGrounded)
                        rigidbody.velocity = new Vector2(FacingDirection * DashSpeedGround, 0);
                    else
                        rigidbody.velocity = new Vector2(FacingDirection * DashSpeed, DashHeight);
                }
            }
        }

        if (movement > 0)
        {
            FacingDirection = 1;
        }
        if (movement < 0)
        {
            FacingDirection = -1;
        }

        if (Health <= 0)
        {
            Health = 10;
            Dying();
        }

        if (interacting)
        {
            rigidbody.velocity = new Vector2(0, 0);
        }
    }

    void Update()
    {
        isGrounded = (Physics2D.Raycast(transform.position + new Vector3(-col.bounds.extents.x, -col.bounds.extents.y, 0.0f), Vector2.down, 0.023f, WhatIsGround) ||
                Physics2D.Raycast(transform.position + new Vector3(col.bounds.extents.x, -col.bounds.extents.y, 0.0f), Vector2.down, 0.023f, WhatIsGround));

        if (!interacting)
        {
            if (isGrounded)
            {
                canResetDash = true;
                isDashing = false;
                if (Input.GetButtonDown("Jump"))
                {
                    isJumping = true;
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpVelocity);
                }

                if (!canDash && canResetDash && dashTimer < dashTimerValue)
                {
                    dashTimer += Time.deltaTime;
                }
                if (!canDash && dashTimer >= dashTimerValue)
                {
                    canDash = true;
                    dashTimer = 0;
                    //Debug.Log("Reset dash");
                }
            }
            else
            {
                if (isJumping)
                {
                    jumpTimer += Time.deltaTime;
                    if (Input.GetButton("Jump") && jumpTimer < maxJumpTime)
                    {
                            rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpVelocity);
                    }
                    else
                    {
                        isJumping = false;
                        jumpTimer = 0;
                    }
                }
                
            }
        }
    }

    public void Dying()
    {
        Instantiate(DeathParticle, transform.position, Quaternion.identity);
        SpriteChangeNormal();
        gameObject.SetActive(false);
        Invoke("ToCenter", 1.0f);
    }

    private void SlowDamage()
    {
        Health--;
        Invoke("SlowDamage", 5);
    }

    //private void DashDelay()
    //{
    //    Dashing = false;
    //}

    public void ToggleInteraction()
    {
        interacting = !interacting;
    }

    public void SpriteChangeYellow()
    {
        spriteRenderer.sprite = YellowSprite;
        StoredColour = MyColour.YELLOW;
        AudioSource.PlayClipAtPoint(Pickedup, transform.position);
    }

    public void SpriteChangePurple()
    {
        spriteRenderer.sprite = PurpleSprite;
        StoredColour = MyColour.PURPLE;
        Invoke("SlowDamage", 5);
        AudioSource.PlayClipAtPoint(Pickedup, transform.position);
    }

    public void SpriteChangeGreenCrystal()
    {
        spriteRenderer.sprite = GreenCrystal;
        StoredColour = MyColour.GREEN;
        rigidbody.gravityScale = 5;
        interacting = false;
    }

    public void SpriteChangeNormal()
    {
        CancelInvoke("SlowDamage");
        spriteRenderer.sprite = NormalSprite;
        StoredColour = MyColour.GREY;
        ObjectHeld = null;
    }

    public void PickUp()
    {
        ObjectHeld.SetActive(false);
    }

    public void ToCenter()
    {
        Instantiate(ReviveParticle, AreaStart, Quaternion.identity);
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }
            transform.position = AreaStart;
    }
}
