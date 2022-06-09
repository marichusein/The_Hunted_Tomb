using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PokreniIgru : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button b;
    void Start()
    {
        b.onClick.AddListener(Pokreni);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pokreni()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
