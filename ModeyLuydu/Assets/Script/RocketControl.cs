using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RocketControl : MonoBehaviour
{
    public Text YukseklikYazisi;
    GameObject roket;
    public Text ButtonYazisiText;
    public Text uyariMesaji;
    public Text KalanHakText;
    public Text DegerSliderValueText;
    public Slider MesafeSlider;
    public Slider DegerSlider;
    bool sliderCalissinmi;
    int geriSAyim = 3;
    bool oyunDurumu;
    Animator rocketAnimator;
    float speed = 0.0f;

    void Start()
    {


        DegerSlider.value = 0;
        sliderCalissinmi = true;
        oyunDurumu = false;
        uyariMesaji.text = "Maximum güç ile kalkış yapmayı dene !";
        rocketAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (oyunDurumu)
        {
            roketCalissin();
        }
        KalanHakText.text = "Kalan Hak :"+geriSAyim;

        if (sliderCalissinmi)
        {
            DegerSlider.value +=1;
            if (DegerSlider.value >= 100)
            {
                geriSAyim--;
               // uyariMesaji.text = "Kalan hak: "+geriSAyim;
                DegerSlider.value = 0;
                if (geriSAyim == 0)
                {
                 //   SceneManager.LoadScene("Menu");
                }
            }
        }
        if (transform.position.y >700)
        {
            rocketAnimator.SetBool("isAnimRun", false);
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
            rocketAnimator.SetBool("isAnimRun",true);
            geriSAyim = 3;

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
    

        if (transform.position.y >= 0 && transform.position.y <= 700)
        {
            speed = DegerSlider.value;
            Debug.Log("Debug: Speed "+speed);
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            ButtonYazisiText.text = transform.position.y + "m";
                MesafeSlider.value = transform.position.y;
           


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
