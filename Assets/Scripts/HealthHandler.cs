using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HealthHandler : MonoBehaviour
{
    [SerializeField]
    private float health = 2f;
    private float invulnTimer = 0;
    public float invulnPeriod = 0;
    private int correctLayer;
    // private Animator anim;
    // private string DESTROY_ANIMATION = "Destroy";

    public int scoreValue;
    public GameObject shield;
    private bool died = false;

    public GameObject explosion;

    void Start()
    {   
        correctLayer = gameObject.layer;

        if (gameObject.layer == 6)
        {
            shield = transform.Find("Shield").gameObject;
            shield.SetActive(false);
        }
    }
    void Update()
    {
        invulnTimer -= Time.deltaTime;

        if (invulnTimer <= 0)
        {
            gameObject.layer = correctLayer;
        }

        if (health <= 0)
        {   
            if (!gameObject.CompareTag("Player"))
            {
                Score.instance.AddScore(scoreValue);
            }
            // anim.SetBool(DESTROY_ANIMATION, true);
            // Score.instance.AddScore(scoreValue);
            if(gameObject.CompareTag("Player")){
                died = true;
            }
            if (!gameObject.CompareTag("Projectile"))
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
            

            Destroy(gameObject);
            if (died) {
                SceneManager.LoadScene("Main Menu");
            }
            
        }

        if (gameObject.transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision) {
        PowerUp powerUp = collision.GetComponent<PowerUp>();
        if (powerUp) {
            if (powerUp.activateShield)
            {
                shield.SetActive(true);
            }
            Destroy(powerUp.gameObject);
        }
        else{
            if (transform.position.x < 9) // invulnTimer <= 0 &&
            {   
                if (gameObject.layer == 6)
                {
                    if (shield.activeSelf)
                    {
                        shield.SetActive(false);
                    }
                    else
                    {
                        health--;
                    }
                }
                else
                {
                    health--;
                }
                // invulnTimer = invulnPeriod;

                // gameObject.layer = 8;
            }
        // health--;
        }
    }
}
