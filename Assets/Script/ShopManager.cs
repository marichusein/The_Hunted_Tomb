using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
using  TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsUI;
    
    
    private void Start()
    {
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
