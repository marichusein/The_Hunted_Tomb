using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
using  TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsUI;
    private GameObject igracSve;
    private PlayerMovement pi;

    public int[,] shopItems = new int[4, 4];
    
    private void Start()
    {
        
        //pi = igracSve.GetComponent<PlayerMovement>();
        coinsUI.text = "Coins: " + coins.ToString();
        
        //id
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        
        //price
        shopItems[2, 1] = 150;
        shopItems[2, 2] =100;
        shopItems[2, 3] = 200;
        shopItems[2, 4] = 150;

    }

    public void buy()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (coins >= shopItems[2, buttonRef.GetComponent<buttonInfo>().itemID])
        {
            coins -= shopItems[2, buttonRef.GetComponent<buttonInfo>().itemID];
            coinsUI.text = "Coins " + coins.ToString();
        }
        
    }
    


    void addCoins()
    {
        coins++;
        coinsUI.text = "Coins " + coins.ToString();
    }
}
