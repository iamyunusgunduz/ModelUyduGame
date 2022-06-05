using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UyduControl : MonoBehaviour
{
    public Text ButtonYazisiText;
    public Text YukseklikYazisi;
    private Rigidbody rb;
    public Slider DegerSlider;
    public GameObject gorevTamamlandiPaneli;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

   

    // Update is called once per frame
    void Update()
    {
        if (rb.useGravity == true && transform.position.y > 420 && transform.position.y <720)
        {

            YukseklikYazisi.text = "Roket kalktı √  \nRoket ayrıldı √";

        }
        if (rb.useGravity == true && transform.position.y > 250 && transform.position.y < 420)
        {
            YukseklikYazisi.text = "Roket kalktı √  \nRoket ayrıldı √  \nGörevYükü Ayrıldı √";

        }
        if (rb.useGravity == true && transform.position.y > 1 && transform.position.y < 250)
        {
            YukseklikYazisi.text = "Roket kalktı √  \nRoket ayrıldı √  \nGörevYükü Ayrıldı √ \nİrtifa Sabitleme √";

        }
        if (rb.useGravity == true && transform.position.y < 1)
        {

            YukseklikYazisi.text = "Roket kalktı √  \nRoket ayrıldı √  \nGörevYükü Ayrıldı √ \nİrtifa Sabitleme √ \nİniş Tamamlandı √";
        }
        if (transform.position.y > 694 && transform.position.y < 720)
        {
            transform.Translate(Vector3.left * 7*Time.deltaTime);

        }

        if (rb.useGravity == true && transform.position.y >-0)
        {
            ButtonYazisiText.text = transform.position.y+"";
            gameObject.transform.Rotate(0.01f, 0.4f, 0);
          
        }
        if(rb.useGravity == true && transform.position.y < -2)
        {
            Time.timeScale = 0;
            gorevTamamlandiPaneli.SetActive(true);

        }
        if (transform.position.y > 695 )
        {


            rb.useGravity = true;

        }
        
     
        if (transform.position.y < 4)
        {
            gameObject.transform.Rotate(0, 0, 0);


        }
    }
}
