using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;

public class ShopScripta : MonoBehaviour
{
    
    public int coins;
    public TMP_Text coinsUI;

    private PlayerMovement p;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        coinsUI.text = "Coins " + p.coins.ToString();

    }
}
