using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyActions : MonoBehaviour
{
    //patrol
    [SerializeField]private Transform[] patrolPoints;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int patrolDestination;

    //Animation
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    //chase
    [SerializeField] private Transform playerTransform;
    [SerializeField] private bool isChasing;
    [SerializeField] private float chaseDistance;
    [SerializeField] private int Life;

    private float x;
    private float y;

    private int inScreen = 25;

    private void Start()
    {
        y = transform.position.y;
        x = transform.position.x;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        /*if (rb.velocity.x > 0)
        {
            anim.SetTrigger("running");
            sprite.flipX = true ;
        }

        if (rb.velocity.x < 0)
        {
            
            sprite.flipX = false;

        }*/

        if (isChasing)
        {
            anim.SetTrigger("running");
            if (transform.position.x > playerTransform.position.x)
            {
                transform.position += Vector3.left * moveSpeed*2 * Time.deltaTime;
                transform.localScale = new Vector3(1, 1, 1);

            }
            else if (transform.position.x < playerTransform.position.x)
            {
                transform.position += Vector3.right * moveSpeed*2 * Time.deltaTime;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Vector2.Distance(transform.position, playerTransform.position) > chaseDistance)
            {
                isChasing = false;
            }
        }
        else
        {
            anim.SetTrigger("Idle");
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
            if (Vector2.Distance(transform.position, playerTransform.position) > inScreen)
            {
                transform.position = new Vector3(x, y, 0);
            }




            if (patrolDestination == 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if(Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    patrolDestination = 1;
                }
            }
            if (patrolDestination == 1)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    patrolDestination = 0;
                }
            }


            

        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Life = Life - 1;
            if (Life == 0)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);
        }
    }


        /**/

}
