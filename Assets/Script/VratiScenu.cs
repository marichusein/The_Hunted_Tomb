using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VratiScenu : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject scena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            scena.SetActive(true);
            shop.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
