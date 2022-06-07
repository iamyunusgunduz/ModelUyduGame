using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BaslangicKontrol : MonoBehaviour
{
 
    public GameObject panel;

   
    void Start()
    {
   

    }
   
    
    void Update()
    {
        
    }

   
   public void panelAcKapa()
    {
        panel.SetActive(false);
        
    }
    public void YenidenOyna()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

