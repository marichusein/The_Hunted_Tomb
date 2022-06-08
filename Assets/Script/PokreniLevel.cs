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

    [SerializeField] private Scene Scena;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider igrac)
    {
        var nScena = SceneManager.GetSceneAt(1);
        SceneManager.MoveGameObjectToScene(igracFUll, nScena);
        SceneManager.LoadScene("Scenes/Shop");
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, igrac.position) < 1.3f)
        {
            SceneManager.LoadScene("Shop");
        }
    }
}
