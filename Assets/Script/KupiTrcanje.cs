using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KupiTrcanje : MonoBehaviour
{
    [SerializeField] private GameObject igracFull;
    private PlayerMovement p;
    [SerializeField] private Button dugme;
    private bool kupljeno;
    void Start()
    {
        p = igracFull.GetComponent<PlayerMovement>();
        dugme.onClick.AddListener(Kupi);
        kupljeno = false;
    }

    // Update is called once per frame
    void Kupi()
    {
        if (!kupljeno)
        {
            if (p.coins >= 100)
            {
                kupljeno = true;
                p.coins -= 100;
                p.runSpeed += 5;
            }
        }
    }
}
