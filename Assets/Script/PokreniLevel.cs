using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PokreniLevel : MonoBehaviour
{
    [SerializeField] private GameObject igracFUll;
    [SerializeField]
    private Transform igrac;

    private PlayerMovement p;
    [SerializeField] private Scene Scena;
    void Start()
    {
        p = igracFUll.GetComponent<PlayerMovement>();
        
    }

    private void OnTriggerEnter(Collider igrac)
    {
        SceneManager.LoadScene("Scenes/Level2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
