using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class ItemCollector : MonoBehaviour
{
    private int strawberries = 0;

    [SerializeField] private Text strawText;
    [SerializeField] private AudioSource pickSoundEffect;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StrawB"))
        {
            pickSoundEffect.Play();
            Destroy(collision.gameObject);
            strawberries++;
            strawText.text = "Strawberries: " + strawberries;
            
        }
    }
}
