using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private 
        Animator anim;
        Rigidbody2D rb;
    float checkpx;
    float checkpy;

    [SerializeField] private Text LifeText;
    [SerializeField] private AudioSource hurtSoundEffect;
    [SerializeField] private AudioSource pickSoundEffect;

    public int Current_Checkpoint = 0;

    public
        int playerLife;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerLife = 1;
    }
    
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spikes") || collision.gameObject.CompareTag("enemy"))
        {
            hurtSoundEffect.Play();
            playerLife = playerLife - 1;
            Debug.Log(playerLife);
            LifeText.text = "X " + playerLife;
        }

        

        if (playerLife == 0)
        {
            Die();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("extralife"))
        {
            pickSoundEffect.Play();
            Destroy(collision.gameObject);
            if (playerLife == 5)
            {

            }
            else
            {
                playerLife++;
                LifeText.text = "X " + playerLife;
            }

        }

        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Current_Checkpoint = 1;
            checkpx = transform.position.x;
            checkpy = transform.position.y;
        }
    }
        private void RestartLevel()
        {
            if (Current_Checkpoint == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                anim.SetBool("death", false);
                
        }
            else
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                transform.position = new Vector3(checkpx, checkpy, 0);
                playerLife = 3; 
                anim.SetBool("death", false);
                LifeText.text = "X " + playerLife;
            Attack.triggerBoss = false;

        }

        }


    private void Die()
    {
        anim.SetBool("death", true);
        rb.bodyType = RigidbodyType2D.Static;
    }

   /* private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}
