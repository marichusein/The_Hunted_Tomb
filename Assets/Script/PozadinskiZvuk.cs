using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PozadinskiZvuk : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public AudioSource zvuk;
    [SerializeField] public AudioClip z;

    
    void Start()
    {
        zvuk.PlayOneShot(z,0.2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
