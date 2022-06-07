using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UyduControl : MonoBehaviour
{
    
    public Text mesafeSliderText;
    public TMP_Text telemetriVerileri;
    public TMP_Text uyariMesaji;
    public Text asamalarText;
    

    public Slider MesafeSlider;
    private Rigidbody rb;
    float donusSayisiHesaplamaIslemi=0;
    public GameObject tasiyicimiz;
    float tasiyiciYukseklik;
    public GameObject roketKonum;
    float lat, lon;
    public Slider DegerSlider;
    int speed;
    float irtifaFarki;
    int cikisValue=30;
    int donusSayisi=0;
    bool donmeOlayi=false;
    
    bool GorevBasladimi=false;
    bool asamaRoketBekleme = false;
    bool asamaRoketFirlatildi = false;
    int inisHizi=0;
    bool asamaTasiyiciAyrildi = false;
    bool asamaUyduAyrildi = false;
    bool asamaUyduSabitkalmaBasladi = false;
    bool asamaUyduSabitkalmaTamamlandi = false;
  
    bool asamaUyduYavaslamaBasladi = false;
    int uyduPaketSayisi = 0;
    string saat;
    bool asamaUyduInisTamamlandi = false;
    public GameObject gorevTamamlandiPaneli;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        asamalarText.text = "Roket beklemede (0m)";
        uyariMesaji.text = "Başarılı kalkış yapmayı dene !";
        
    }
    private void FixedUpdate()
    {




        inisHizi = speed;

        irtifaFarki =MathF.Abs( (transform.position.y) - (tasiyiciYukseklik));
        LocationInfo li = new LocationInfo();

        lat = li.latitude;
        lon = li.longitude;
        if (tasiyicimiz.transform.position.y < 2)
        {
            tasiyiciYukseklik = 0;
        }
        else
        {
            tasiyiciYukseklik = tasiyicimiz.transform.position.y;
        }
        float pitchValue = transform.rotation.x;
        float yawValue = transform.rotation.y;
        float rollValue = transform.rotation.z;
        saat = DateTime.Now.ToString("hh:MM:ss");
        
        telemetriVerileri.text = "Takım No: 12345\n" +
"Paket Numarası : " + uyduPaketSayisi + "\n" +
"Gönderme Saati : " + saat + "\n" +
"Uydu Basınç : 144.1 mP\n" +
"Taşıyıcı Basınç: 124.3 mP\n" +
"Uydu Yükseklik: " + transform.position.y + "m\n" +
"Taşıyıcı Yükseklik: " + tasiyiciYukseklik + "m\n" +
"İrtifa Farkı: " + irtifaFarki + "m\n" +
"İniş Hızı " + inisHizi + "m/s\n" +
"Uydu Sicaklik :  30 °C\n" +
"Pil Gerilimi: 4.1 V\n" +
"Uydu Pitch: " + pitchValue + "\n" +
"Uydu Roll : " + rollValue + "\n" +
"Uydu Yaw : " + yawValue + "\n";
    }
    void Update()
    {
        MesafeSlider.value = transform.position.y;
        mesafeSliderText.text = "Uydu Yukseklik " + transform.position.y + "m";

        

        if (transform.position.y >= 690)
        {
            GorevBasladimi = true;
            donmeOlayi = true;
            speed = 50;
           
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
                        gameObject.transform.Rotate(0, 5f, 0);
         

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
            uyduPaketSayisi++;
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
            speed = 0;
            donmeOlayi = false;
            Invoke("oyunTamamlandi", 2);
        }
    }


   public void OnSaniyeGeriSayim()
    {

                asamaUyduSabitkalmaBasladi = false;
      

    }
    public void oyunTamamlandi()
    {
        gorevTamamlandiPaneli.SetActive(true);
    }
   
}
