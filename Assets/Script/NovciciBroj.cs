using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;


public class NovciciBroj : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject p; 
    public TMP_Text coinsUI;
    private PlayerMovement pi;
    private void Start()
    {
        pi = p.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        coinsUI.text = ": " + pi.coins;
    }
}
