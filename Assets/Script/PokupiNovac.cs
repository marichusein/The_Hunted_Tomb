using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokupiNovac : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform igrac;
    [SerializeField]
    private GameObject zaKraj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, igrac.position) < 2.5f)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                GameObject.Destroy(gameObject);
                var Vec = new Vector3(130.41f, 0.23f, 129.3f);
                Instantiate(zaKraj, Vec, Quaternion.identity);
            }
           
        }
        
    }
}
