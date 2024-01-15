using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Aim : StateMachineBehaviour
{
   
    public float speed = 10f;
    public float speed2 = 12f;
    public float attackRange = 20f;
    Transform player;
    Rigidbody2D rb;
    Boss boss;
    float timer;
    int delay = 3;
    bool done = false;
    private float x;
    private float y;

   
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        x = rb.position.x;
        y = rb.position.y;


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        timer += Time.deltaTime;
        Vector2 target = new Vector2(player.position.x, y);
        Vector2 target2 = new Vector2(rb.position.x, y-10);
        Vector2 target3 = new Vector2(rb.position.x, y+10);

        if (!done)
        { 
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
            Debug.Log("dumb");
        }

      

            if (Vector2.Distance(player.position, rb.position) <= attackRange && done == false)
        {
           
                Debug.Log("dumbv2");
            if (timer > delay)
            {

                if (player.position.y > y)
                {
                    Vector2 pos3 = Vector2.MoveTowards(rb.position, target3, speed2 * Time.fixedDeltaTime);
                    rb.MovePosition(pos3);

                   

                }
                else
                {
                    Vector2 pos2 = Vector2.MoveTowards(rb.position, target2, speed2 * Time.fixedDeltaTime);
                    rb.MovePosition(pos2);
                      

                }

            }
        }
        Transform initpos = GameObject.Find("initpos").transform;
        Vector2 pos4 = Vector2.MoveTowards(rb.position, initpos.position, speed2 * Time.fixedDeltaTime);
        if (rb.position.y == y+10 || rb.position.y == y - 10)
        {

            done = true;

        }
        if (done == true)
        {
            Debug.Log("doing1");
           
            rb.MovePosition(pos4);
            if (rb.position.x == initpos.position.x)
            {
                Attack.finish = true;
                Debug.Log("reset");
                done = false;
                animator.SetInteger("Attack", 0);
                
            }
        }
       
        
        
/*
        if (rb.position.y < -3.9)
        {
            done = true;
            Debug.Log("doing");
            Vector2 pos4 = Vector2.MoveTowards(rb.position, initpos.position, speed2 * Time.fixedDeltaTime);
            rb.MovePosition(pos4);
            if (rb.position.x == initpos.position.x)
            {
                Debug.Log("reset2");
                animator.SetInteger("Attack", 0);
            }

        }*/

    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
    }
}