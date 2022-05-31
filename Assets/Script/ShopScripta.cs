using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;

public class ShopScripta : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public int coins;
    public TMP_Text coinsUI;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = new PlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {
        coinsUI.text = "Coins " + playerMovement.coins.ToString();

    }
}
