using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSign : MonoBehaviour
{
    private float sinCenterY;

    [SerializeField]
    private float amp = 2;

    [SerializeField]
    private float freq = 2;

    [SerializeField]
    private bool inverted;

    // Start is called before the first frame update
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x + freq) * amp;

        if (inverted)
        {
            sin *= -1;
        }

        pos.y = sinCenterY + sin;

        transform.position = pos;
    }
}
