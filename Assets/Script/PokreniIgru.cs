using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PokreniIgru : MonoBehaviour
{
    [SerializeField] private Button pocetak;

   
     private void Start()
    {
        pocetak.onClick.AddListener(PokreniScenu);
    }

     void PokreniScenu()
     {
         SceneManager.LoadScene("SampleScene");
     }
}
