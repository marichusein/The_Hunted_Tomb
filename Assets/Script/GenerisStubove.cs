using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerisStubove : MonoBehaviour
{
   [SerializeField] private GameObject objektkojidupliramo;

   private void Start()
   {
      for (int i = 0; i < 45; i++)
      {
         Vector3 pozicija = new Vector3(Random.Range(-90f, 90f), 0, Random.Range(-90f, 90f));
         Instantiate(objektkojidupliramo, pozicija, Quaternion.identity);
      }
   }
}
