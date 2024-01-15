using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHand : MonoBehaviour
{

    [SerializeField] private Transform player;
    // Update is called once per frame
    void Update()
    { 
        if(PlayerMovement.playerSpriteDirection == false)
        {
            transform.position = new Vector3(player.position.x + 1.2f, transform.position.y, transform.position.z);
        }
        else if (PlayerMovement.playerSpriteDirection == true)
        {
            transform.position = new Vector3(player.position.x - 1.2f, transform.position.y, transform.position.z);
        }
    }
}
