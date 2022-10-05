using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 8f;
    public float deactivateTimer = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateProjectile", deactivateTimer);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;

        transform.position = temp;
    }

    void DeactivateProjectile() {
        gameObject.SetActive(false);
    }
}
