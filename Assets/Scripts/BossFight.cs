using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Attack.triggerBoss == false)
        {
            Attack.triggerBoss = true;
        }
    }

}
