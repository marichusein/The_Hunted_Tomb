using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokupi_Coins : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject igrac;
    private PlayerMovement _playerMovement;
    void Start()
    {
        _playerMovement = new PlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(igrac.transform.position, transform.position) < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerMovement.coins += 10;
                GameObject.Destroy(gameObject);
            }
        }
   
    }
}
