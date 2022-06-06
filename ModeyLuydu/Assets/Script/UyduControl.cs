using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UyduControl : MonoBehaviour
{
    public Text ButtonYazisiText;
    public Text mesafeSliderText;
    public Text asamalarText;
    public Text uyariMesaji;
    public Slider MesafeSlider;
    private Rigidbody rb;
    public GameObject tasiyicimiz;
    public GameObject roketKonum;
    public Slider DegerSlider;
    int speed;
    int cikisValue=15;
    bool donmeOlayi=false;
    bool GorevBasladimi=false;
    bool asamaRoketBekleme = false;
    bool asamaRoketFirlatildi = false;
    bool asamaTasiyiciAyrildi = false;
    bool asamaUyduAyrildi = false;
    bool asamaUyduSabitkalmaBasladi = false;
    bool asamaUyduSabitkalmaTamamlandi = false;
    bool asamaUyduYavaslamaBasladi = false;
    bool asamaUyduInisTamamlandi = false;
    public GameObject gorevTamamlandiPaneli;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        asamalarText.text = "Roket beklemede (0m)";
        uyariMesaji.text = "Başarılı kalkış yapmayı dene !";
    }

    void Update()
    {
        MesafeSlider.value = transform.position.y;
        mesafeSliderText.text = "Uydu Yukseklik " + transform.position.y + "m";

        

        if (transform.position.y >= 690)
        {
            GorevBasladimi = true;
            donmeOlayi = true;
            speed = 75;
            transform.Translate(Vector3.left * cikisValue * Time.deltaTime);
        }
        if (transform.position.y <=+0)
        {
            speed = 0;
            donmeOlayi = false;
            
        }

        if (GorevBasladimi)
        {
                    if (asamaUyduSabitkalmaBasladi==false)
                    {
                        transform.Translate(Vector3.down * speed * Time.deltaTime);
                    }
          
                    if (donmeOlayi)
                    {
                        gameObject.transform.Rotate(0.01f, 0.4f, 0);
              

                    }
        }  else
        {
            transform.position = roketKonum.transform.position;
            speed = 0;
            donmeOlayi = false;
           
        }

        if (!GorevBasladimi && transform.position.y>10)
        {
            asamalarText.text = "Roket beklemede (0m)\n" +
            "Roket Kalkis Yapti(1m)\n";
            uyariMesaji.text = "Roket Kalkis Yapti(1m)";
        }
        if (GorevBasladimi && transform.position.y <= 690)
        {
            asamalarText.text = "Roket beklemede (0m)\n" +
            "Roket Kalkis Yapti(1m)\n" +
    "Roket & Tasiyici Ayrildi(690m)\n";
            uyariMesaji.text = "Roket & Tasiyici Ayrildi(690m)";
        }
        if (GorevBasladimi && transform.position.y <= 401)
        {
            asamaTasiyiciAyrildi = true;
            asamalarText.text = "Roket beklemede (0m)\n" +
            "Roket Kalkis Yapti(1m)\n" +
    "Roket & Tasiyici Ayrildi(700m)\n"+
     "Tasiyici & Uydu Ayrildi(400m)\n";
            uyariMesaji.text = "Tasiyici & Uydu Ayrildi(400m)";
        }

        if (asamaTasiyiciAyrildi)
        {
            tasiyicimiz.transform.Translate(Vector3.left * 20 * Time.deltaTime);
        }

        if (GorevBasladimi && transform.position.y <= 201)
        {
            asamaUyduSabitkalmaBasladi = true;

            Invoke("OnSaniyeGeriSayim", 10);
            asamaTasiyiciAyrildi = true;
            asamalarText.text = "Roket beklemede (0m)\n" +
            "Roket Kalkis Yapti(1m)\n" +
    "Roket & Tasiyici Ayrildi(700m)\n" +
     "Tasiyici & Uydu Ayrildi(400m)\n" +
    "Asılı kalma Basladi(200m)\n";
            uyariMesaji.text = "Asılı kalma Basladi(200m)";
        }

        if (GorevBasladimi && transform.position.y <= 199)
        {
           

            asamalarText.text = "Roket beklemede (0m)\n" +
          "Roket Kalkis Yapti(1m)\n" +
  "Roket & Tasiyici Ayrildi(700m)\n" +
   "Tasiyici & Uydu Ayrildi(400m)\n" +
  "Asılı kalma Basladi(200m)\n" +
  "Sabit kalma Tamamlandi(200m)\n";
            uyariMesaji.text = "Sabit kalma Tamamlandi(200m)";
        }



        if (GorevBasladimi && transform.position.y <= 21)
        {
            speed = 10;
            asamalarText.text = "Roket beklemede (0m)\n" +
          "Roket Kalkis Yapti(1m)\n" +
  "Roket & Tasiyici Ayrildi(700m)\n" +
   "Tasiyici & Uydu Ayrildi(400m)\n" +
  "Asılı kalma Basladi(200m)\n" +
  "Sabit kalma Tamamlandi(200m)\n" +
    "İniş Yavaşlatma başladı(20m)\n";
            uyariMesaji.text = "İniş Yavaşlatma başladı(20m)";
        }


        if (GorevBasladimi && transform.position.y <= 11)  {
            speed = 5;
            asamalarText.text = "Roket beklemede (0m)\n" +
         "Roket Kalkis Yapti(1m)\n" +
 "Roket & Tasiyici Ayrildi(700m)\n" +
  "Tasiyici & Uydu Ayrildi(400m)\n" +
 "Asılı kalma Basladi(200m)\n" +
 "Sabit kalma Tamamlandi(200m)\n" +
   "İniş Yavaşlatma başladı(20m)\n" +
    "Görev Tamamlandı √\n";
            uyariMesaji.text = "Görev Tamamlandı √";
        }



        if (GorevBasladimi && transform.position.y <= 1) {
            asamalarText.text = "Roket beklemede (0m)\n" +
          "Roket Kalkis Yapti(1m)\n" +
  "Roket & Tasiyici Ayrildi(700m)\n" +
   "Tasiyici & Uydu Ayrildi(400m)\n" +
  "Asılı kalma Basladi(200m)\n" +
  "Sabit kalma Tamamlandi(200m)\n" +
    "İniş Yavaşlatma başladı(20m)\n" +
    "Görev Tamamlandı √\n" +
    "İniş Tamamlandi(0m)";
            uyariMesaji.text = "İniş Tamamlandi(0m)";
        }
    }


   public void OnSaniyeGeriSayim()
    {

                asamaUyduSabitkalmaBasladi = false;
      

    }
}
