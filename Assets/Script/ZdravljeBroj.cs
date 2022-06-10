using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;

public class ZdravljeBroj : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject g;
    private PlayerMovement p;
    private int max = 0;
    private int trenutno;
    public TMP_Text coinsUI;
    private string kolikoIma = " ";
    private float Procenat;
    
    void Start()
    {
        p = g.GetComponent<PlayerMovement>();
        max = p.zdravlje;
    }

    // Update is called once per frame
    void Update()
    {
        trenutno = p.zdravlje;
        Procenat = (((float)trenutno / max) * 100f);
        coinsUI.text = ": " + Procenat;
    }
}
