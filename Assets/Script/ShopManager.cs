using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
using  TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsUI;
    private GameObject igracSve;
    private PlayerMovement pi;
    private void Start()
    {
        
        //pi = igracSve.GetComponent<PlayerMovement>();
        coinsUI.text = "Coins: " + coins.ToString();
        
    }

    private void Update()
    {
        
    }


    void addCoins()
    {
        coins++;
        coinsUI.text = "Coins " + coins.ToString();
    }
}
