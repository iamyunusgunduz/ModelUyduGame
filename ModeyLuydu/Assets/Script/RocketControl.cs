using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RocketControl : MonoBehaviour
{
   
    int roketDurumu;
    public GameObject panel;
    public Text ButtonYazisiText;
    public Text uyariMesaji;
    public Text KalanHakText;
    public Text DegerSliderValueText;
  
   
    public Slider DegerSlider;
  public static  bool sliderCalissinmi;
    int geriSAyim = 3;
    bool oyunDurumu;
    private Rigidbody rb;
    float speed = 0.0f;

    void Start()
    {

        roketDurumu = 0;
        DegerSlider.value = 0;
        sliderCalissinmi = false;
        oyunDurumu = false;
        uyariMesaji.text = "Başarılı kalkış yapmayı dene !";
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {


        if (transform.position.y >= 700)
        {
            roketDurumu = -1;
        }
        if (roketDurumu == -1 && transform.position.y<2)
        {
            roketDurumu = 0;
        }
        if (oyunDurumu)
        {
            if (roketDurumu==1)
            {
                RoketYuksel();
            }
            if (roketDurumu==-1 && transform.position.y > 4)
            {
                RoketIn();
            }
            

           
         
        }
        


        if (sliderCalissinmi)
        {
            KalanHakText.text = "Kalan Hak : " + geriSAyim;
            DegerSlider.value ++ ;
            if (DegerSlider.value >= 100)
            {
                --geriSAyim;
                DegerSlider.value = 0;
                
            }
            if (geriSAyim == -1)
            {
                panel.SetActive(true);
                geriSAyim = 3;
                DegerSlider.value = 0;
                sliderCalissinmi = false;

            }
        } else{  KalanHakText.text = " "; }
        
        DegerSliderValueText.text = DegerSlider.value + "";
    }


   
    
    public void degerSliderControl()
    {
       
          
        if (DegerSlider.value >= 85)
        {
           
            oyunDurumu = true;
            sliderCalissinmi = false;
            uyariMesaji.text = "%" + DegerSlider.value + " itki ile kalkış yaptın";
            roketDurumu = 1;
            Invoke("mesajSil", 1);
        }
        if (DegerSlider.value >= 50 && DegerSlider.value < 85)
        {
            uyariMesaji.text = "%" + DegerSlider.value + " itki yeterli değil ";
        }
        if (DegerSlider.value >= 0 && DegerSlider.value < 50)
        {
            uyariMesaji.text = "%" + DegerSlider.value + " itki ile roket havalanamadı ";
        }


       


    }

  public void RoketYuksel()
    {
        speed = DegerSlider.value;
        Debug.Log("Debug: Speed " + speed);
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    public void RoketIn()
    {
        speed = 40;
        Debug.Log("Debug: Speed " + speed);
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void mesajSil()
    {
        uyariMesaji.text = "  ";
       
    }
}
