using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaslangicKontrol : MonoBehaviour
{
    
    public GameObject RoketRed;
    public  GameObject RoketYellow;
    public  GameObject RoketPink;
    public  GameObject RoketOrange;
    public  GameObject RoketGrey;
    public  GameObject RoketGreen;
    public  GameObject RoketBlue;
    public TextMeshProUGUI output;
    public GameObject panel;

    public void HandleUnputData(int val)
    {
        
        if (val ==1)
        {
            RoketRed.SetActive(false);
            RoketYellow.SetActive(true);
            RoketPink.SetActive(false);
            RoketOrange.SetActive(false);
            RoketGrey.SetActive(false);
            RoketGreen.SetActive(false);
            RoketBlue.SetActive(false);
        }
        if (val == 2)
        {
            RoketRed.SetActive(false);
            RoketYellow.SetActive(false);
            RoketPink.SetActive(true);
            RoketOrange.SetActive(false);
            RoketGrey.SetActive(false);
            RoketGreen.SetActive(false);
            RoketBlue.SetActive(false);
        }
        if (val == 3)
        {
            RoketRed.SetActive(false);
            RoketYellow.SetActive(false);
            RoketPink.SetActive(false);
            RoketOrange.SetActive(true);
            RoketGrey.SetActive(false);
            RoketGreen.SetActive(false);
            RoketBlue.SetActive(false);
        }
        if (val == 4)
        {
            RoketRed.SetActive(false);
            RoketYellow.SetActive(false);
            RoketPink.SetActive(false);
            RoketOrange.SetActive(false);
            RoketGrey.SetActive(true);
            RoketGreen.SetActive(false);
            RoketBlue.SetActive(false);
        }
        if (val == 5)
        {
            RoketRed.SetActive(false);
            RoketYellow.SetActive(false);
            RoketPink.SetActive(false);
            RoketOrange.SetActive(false);
            RoketGrey.SetActive(false);
            RoketGreen.SetActive(true);
            RoketBlue.SetActive(false);
        }
        if (val == 6)
        {
            RoketRed.SetActive(false);
            RoketYellow.SetActive(false);
            RoketPink.SetActive(false);
            RoketOrange.SetActive(false);
            RoketGrey.SetActive(false);
            RoketGreen.SetActive(false);
            RoketBlue.SetActive(true);
        }
    }
    void Start()
    {

        
            RoketRed.SetActive(true);
            RoketYellow.SetActive(false);
            RoketPink.SetActive(false);
            RoketOrange.SetActive(false);
            RoketGrey.SetActive(false);
            RoketGreen.SetActive(false);
            RoketBlue.SetActive(false);
        

    }
   
    
    void Update()
    {
        
    }

   public void panelAcKapa()
    {
        panel.SetActive(false);
    }
}
