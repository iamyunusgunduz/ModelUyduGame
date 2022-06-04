using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UyduControl : MonoBehaviour
{
    public Text ButtonYazisiText;
    private Rigidbody2D rb;
    public Slider DegerSlider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.y > 690)
        {
            transform.Translate(Vector3.up * Time.deltaTime);

        }

        if (rb.gravityScale ==1 && transform.position.y >0)
        {
            ButtonYazisiText.text = transform.position.y+"";
            gameObject.transform.Rotate(0.01f, 0.4f, 0);
        }
        if (transform.position.y > 695 )
        {
           

            rb.gravityScale = 1;

        }
    }
}
