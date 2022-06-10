using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodajSoundNaPocetnu : MonoBehaviour
{

    [SerializeField] public AudioSource zvuk;
    [SerializeField] public AudioClip z;
    
    // Start is called before the first frame update
    void Start()
    {
        zvuk.PlayOneShot(z);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
