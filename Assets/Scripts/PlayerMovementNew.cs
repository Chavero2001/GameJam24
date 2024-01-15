using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tf;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    public static bool playerSpriteDirection = true;

    [SerializeField] private LayerMask jumpableGround;

    public static float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    private float jumpForce = 14f;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    private bool gravity = true;

    private enum Movementstate { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello, world!");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Edit -> Project Settings -> Input Manager

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0f)
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            jumpBufferCounter = 0;
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
        if (Input.GetButton("Fire2"))
        {
            if (gravity == true)
            {
                transform.localScale = new Vector3(1, -1, 1);
                rb.gravityScale = -3;
                jumpForce = -1 * jumpForce;
                gravity = false;
            }
        }
        if (Input.GetButton("Fire3"))
        {
            if (gravity == false)
            {
                transform.localScale = new Vector3(1, 1, 1);
                rb.gravityScale = 3;
                jumpForce = -1 * jumpForce;
                gravity = true;
            }

        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        Movementstate state;
        if (dirX > 0f)
        {
            state = Movementstate.running;
            sprite.flipX = false;
            playerSpriteDirection = false;
        }
        else if (dirX < 0f)
        {
            state = Movementstate.running;
            sprite.flipX = true;
            playerSpriteDirection = true;
        }
        else
        {
            state = Movementstate.idle;

        }

        if (rb.velocity.y > .1f)
        {
            state = Movementstate.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = Movementstate.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {

        if (gravity == false)
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.up, .1f, jumpableGround);
        }
        else
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        }
    }
    private void shoot()
    {
        anim.SetBool("Shoot", false);
    }
}
