using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UyduControl : MonoBehaviour
{
    public Text ButtonYazisiText;
    public Text YukseklikYazisi;
    private Rigidbody2D rb;
    public Slider DegerSlider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.gravityScale == 1 && transform.position.y > 420 && transform.position.y <720)
        {
            YukseklikYazisi.text = "Roket kalktı √  \nRoket ayrıldı √  \nGörevYükü Ayrıldı - \nİrtifa Sabitleme - \nİniş Tamamlandı -";

        }
        if (rb.gravityScale == 1 && transform.position.y > 250 && transform.position.y < 420)
        {
            YukseklikYazisi.text = "Roket kalktı √  \nRoket ayrıldı √  \nGörevYükü Ayrıldı √ \nİrtifa Sabitleme - \nİniş Tamamlandı -";

        }
        if (rb.gravityScale == 1 && transform.position.y > 1 && transform.position.y < 250)
        {
            YukseklikYazisi.text = "Roket kalktı √  \nRoket ayrıldı √  \nGörevYükü Ayrıldı √ \nİrtifa Sabitleme √ \nİniş Tamamlandı -";

        }
        if (rb.gravityScale == 1 && transform.position.y < 1)
        {

            YukseklikYazisi.text = "Roket kalktı √  \nRoket ayrıldı √  \nGörevYükü Ayrıldı √ \nİrtifa Sabitleme √ \nİniş Tamamlandı √";
        }
        if (transform.position.y > 690)
        {
            transform.Translate(Vector3.up * Time.deltaTime);

        }

        if (rb.gravityScale ==1 && transform.position.y >-0)
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
