using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_behavior : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 14f;
    private bool direction = false;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float x;

    void Start()
    {

        direction = PlayerMovement.playerSpriteDirection == true ? true : false;
        Invoke("selfdestruct", 1f);
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        x = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {

           if(direction == true) {
                transform.Translate((-bulletSpeed) * Time.deltaTime, 0, 0);
            }

            else {
                transform.Translate((bulletSpeed)*Time.deltaTime , 0, 0);
            }

            if (transform.position.x > x)
            {
            sprite.flipX = false;
            }

        if (transform.position.x < x)
        {
            sprite.flipX = true;
        }




    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    private void selfdestruct()
    {
        Destroy(gameObject);
    }
}
