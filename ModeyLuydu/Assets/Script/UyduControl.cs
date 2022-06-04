using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UyduControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public Slider DegerSlider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 700 )
        {
            if (DegerSlider.value >= 90)
            {
                rb.gravityScale = 1;
            }

        }
    }
}
