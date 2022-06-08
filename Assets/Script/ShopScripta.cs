using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using  TMPro;

public class ShopScripta : MonoBehaviour
{
    
    public int coins;
    public TMP_Text coinsUI;
    [SerializeField] private GameObject igracfull;
    private PlayerMovement p;
    // Start is called before the first frame update
    void Start()
    {
        p = igracfull.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        coinsUI.text = "Coins: " + p.coins.ToString();

    }
}
