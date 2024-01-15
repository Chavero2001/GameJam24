using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    private BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coll.offset = new Vector2(0,100);
        }
    }
    /*playerLife script:
     * public int Current_Checkpoint = 0;
     * in on trigger
     *         if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Current_Checkpoint += 1;
        }
        private void RestartLevel()
    {
        if (Current_Checkpoint == 0) { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }
        else{
        rb.bodyType = RigidbodyType2D.Dynamic;
            tf.position = new Vector3(16, 37,0);
    }
        */
}
