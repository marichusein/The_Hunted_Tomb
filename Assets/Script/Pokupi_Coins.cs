using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokupi_Coins : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform igrac;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(igrac.position, transform.position) < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject.Destroy(gameObject);
            }
        }
   
    }
}
