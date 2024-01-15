using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombatManager : MonoBehaviour
{
    private Animator anim;
    public Projectile_behavior ProjectilePrefab;
    public Transform LaunchOffset;
    public static bool shot = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && shot == false )
        {
            anim.SetBool("Shoot", true);
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            shot = true;
            Invoke("shoot", 1f);

        }
        
    }
    void shoot()
    {
        shot = false;
        anim.SetBool("Shoot", false);

    }
}
