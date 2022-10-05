using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float minY, maxY;

    [SerializeField]
    private GameObject playerProjectile;

    [SerializeField]
    private Transform projectileSpawn;

    private static string AXIS_VERT = "Vertical";
    // private static string ATTACK_KEY = "Jump";

    [SerializeField]
    private float attackTimer = 0.45f;
    private float currentAttackTimer;
    private bool canShoot;
    // public GameObject shield;


    void Start()
    {
        // shield = transform.Find("Shield").gameObject;
        currentAttackTimer = attackTimer;
    }

    void Update()
    {
        MovePlayer();
        Shoot();
    }
    
    void MovePlayer()
    {
        if (Input.GetAxisRaw(AXIS_VERT) > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if (temp.y > maxY)
            {
                temp.y = maxY;
            }

            transform.position = temp;
        }
        else if (Input.GetAxisRaw(AXIS_VERT) < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < minY)
            {
                temp.y = minY;
            }

            transform.position = temp;
        }
    }

    void Shoot()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > currentAttackTimer)
        {
            canShoot = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canShoot) {
                canShoot = false;
                attackTimer = 0f;

                Instantiate(playerProjectile, projectileSpawn.position, transform.rotation);
                // play sound
            }
        }
    }

    // public void ActivateShield()
    // {
    //     shield.SetActive(true);
    // }

    // public void DeactivateShield()
    // {
    //     shield.SetActive(false);
    // }

    // bool HasShield()
    // {
    //     return shield.activeSelf;
    // }
}
