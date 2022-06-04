using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RocketControl : MonoBehaviour
{
    public Text YukseklikYazisi;

    public GameObject panel;
    public Text ButtonYazisiText;
    public Text uyariMesaji;
    public Text KalanHakText;
    public Text DegerSliderValueText;
    public Slider MesafeSlider;
    public Slider DegerSlider;
  public static  bool sliderCalissinmi;
    int geriSAyim = 3;
    bool oyunDurumu;
  
    float speed = 0.0f;

    void Start()
    {


        DegerSlider.value = 0;
        sliderCalissinmi = false;
        oyunDurumu = false;
        uyariMesaji.text = "Maximum güç ile kalkış yapmayı dene !";
  
    }

    void Update()
    {
        if (transform.position.y < 0)
        {
            uyariMesaji.text = "Roket yok yoldu";
        }
        if (oyunDurumu)
        {
            roketCalissin();
        }
        KalanHakText.text = "Kalan Hak : "+geriSAyim;
    
        if (sliderCalissinmi)
        {
            DegerSlider.value +=1;
            if (DegerSlider.value >= 100)
            {

                --geriSAyim;
                DegerSlider.value = 0;
                if (geriSAyim == -1)
                {
                    panel.SetActive(true);
                    geriSAyim = 3;
                    DegerSlider.value = 0;
                    sliderCalissinmi = false;

                }
            }
        }
        if (KalanHakText.text == "Kalan Hak : 0")
        {
            if (transform.position.y > 50 && transform.position.y < 470) { gameObject.transform.Rotate(0, 0, -0.3f); }
        }
        if (KalanHakText.text == "Kalan Hak : 3")
        {
            if (transform.position.y > 50 && transform.position.y < 170) { gameObject.transform.Rotate(0, 0, -0.3f); }
        }
        if (KalanHakText.text == "Kalan Hak : 2")
        {
            if (transform.position.y > 350 && transform.position.y < 670) { gameObject.transform.Rotate(0, 0, -0.3f); }
        }
        if (KalanHakText.text == "Kalan Hak : 1")
        {
            if (transform.position.y > 150 && transform.position.y < 370) { gameObject.transform.Rotate(0, 0, -0.3f); }
        }

        if (transform.position.y >700)
        {
           
            uyariMesaji.text = "Başarılı bir ayrılma gerçekleştir !";

         
            
        }
        
        DegerSliderValueText.text = DegerSlider.value + "";
    }
   

  
    public void degerSliderControl()
    {
       
          
            if (DegerSlider.value >= 85) {
            oyunDurumu = true;
             
            sliderCalissinmi = false;
            uyariMesaji.text = "%" + DegerSlider.value + " Güç ile kalkış yaptın";
      
           

            Invoke("mesajSil", 1);
        }
        if (DegerSlider.value >= 50 && DegerSlider.value < 85)
        {
            uyariMesaji.text = "%" + DegerSlider.value + " itki yeterli değil ";
        }
        if (DegerSlider.value >= 10 && DegerSlider.value < 50)
        {
            uyariMesaji.text = "%" + DegerSlider.value + " roket havalanamadı ";
        }


       


    }
    public  void roketCalissin()
    {
        MesafeSlider.value = transform.position.y;

        if (transform.position.y >= 0 && transform.position.y <= 700)
        {
            speed = DegerSlider.value;
            Debug.Log("Debug: Speed "+speed);
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            ButtonYazisiText.text = transform.position.y + "m";
              

            KalanHakText.text = "";

            } else {
           
            speed = 1;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        }
    
            
    }
    public void mesajSil()
    {
        uyariMesaji.text = "  ";
       
    }
}
