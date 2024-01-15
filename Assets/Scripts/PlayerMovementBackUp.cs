using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class PlayerMovement : MonoBehaviour
{
    private
        Rigidbody2D rb;
        BoxCollider2D coll;
        Animator anim;
        float dirX = 0;
        SpriteRenderer sprite;
        [SerializeField]float moveSpeed = 7;
        [SerializeField]float jumpForce = 14;
        [SerializeField] LayerMask jumpableGround;
       

    enum MovementState { idle, running, jumping, falling };

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello,world");
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
{
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        UpdateAnimation();

        if (Input.GetButtonDown("Jump")&& IsGrounded())
        {
           rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


            
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1)
        {
            state = MovementState.jumping;
        }
        if (rb.velocity.y < -0.1)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
*/