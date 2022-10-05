using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    [SerializeField]
    private GameObject alienProjectile;

    [SerializeField]
    private Transform projectileSpawn;

    [SerializeField]
    // private float attackTimer = 0.7f;
    // private float currentAttackTimer;
    // private bool canShoot;

    private bool autoAttack;
    private float attackIntervalSeconds = 2f;
    private float attackDelaySeconds = 0.2f;
    private float attackTimer = 0f;
    private float delayTimer = 0f;


    void Start()
    {

    }

    void Update()
    {   
        

        if (autoAttack && transform.position.x < 9f)
        {
            if (delayTimer >= attackDelaySeconds)
            {
                if (attackTimer >= attackIntervalSeconds)
                {
                    Shoot();
                    attackTimer = 0f;
                }
                else
                {
                    attackTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;
            }    
        }
    }

    void Shoot()
    {
        Instantiate(alienProjectile, projectileSpawn.position, transform.rotation);
        // play sound
    }
}
