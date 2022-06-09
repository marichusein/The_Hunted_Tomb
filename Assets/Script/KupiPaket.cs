using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KupiPaket : MonoBehaviour
{
    [SerializeField] private GameObject igracFull;
    private PlayerMovement p;
    [SerializeField] private Button dugme;
    private bool kupljeno;
    // Start is called before the first frame update
    void Start()
    {
        p = igracFull.GetComponent<PlayerMovement>();
        dugme.onClick.AddListener(Kupi);
        kupljeno = false;
    }

    void Kupi()
    {
        if (!kupljeno)
        {
            if (p.coins >= 150)
            {
                kupljeno = true;
                p.coins -= 150;
                p.walkSpeed += 15;
                p.zdravlje += 1000;
            }
        }
    }
}
