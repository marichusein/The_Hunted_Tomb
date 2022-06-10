using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class KretanjeNeprijatelja : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField]  GameObject igrac;
    [SerializeField] private GameObject coin;

    [SerializeField] private AudioSource mumija;
    
    [SerializeField] private AudioClip kretanje;
    [SerializeField] private AudioClip udarac;
    [SerializeField] private AudioClip smrt;


    


 [SerializeField]  
 private Transform player;

 private Animator an;
 [SerializeField] private UnityEngine.AI.NavMeshAgent agent;

    
    private int zdravlje = 3;
    
    public float enemyDistance = 0.7f;

    private void Awake()
    {
        playerMovement = igrac.GetComponent<PlayerMovement>();
    }

    void Start()
    {
        an = GetComponentInChildren<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (zdravlje != 0)
        {
            transform.LookAt(player);

            agent.SetDestination(player.position);
            an.SetFloat("Speed", 0);

            if (Vector3.Distance(transform.position, player.position) < enemyDistance*10.2f)
            {
                an.SetFloat("Speed", 1);

                if (!mumija.isPlaying)
                {
                    mumija.PlayOneShot(kretanje);
                }
            }
            if (Vector3.Distance(transform.position, player.position) < enemyDistance)
            {
                gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().velocity = Vector3.zero;
                an.SetTrigger("Attack");
                playerMovement.anim.SetTrigger("Udarac");
                
                if (!mumija.isPlaying)
                {
                    mumija.PlayOneShot(udarac);
                }

                if (an.hasBoundPlayables)
                {
                    playerMovement.zdravlje--;
                }


                if (playerMovement.zdravlje <= 0)
                {
                    an.SetFloat("Speed", 0);
                    playerMovement.anim.SetTrigger("Smrt");
                    //StartCoroutine(ChangeAfter2SecondsCoroutine());
                   SceneManager.LoadScene("EndGame");

                }
                //gameObject.GetComponent<Animator>().Play("attack");
            
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().velocity = Vector3.zero;
                    zdravlje = zdravlje - playerMovement.udarac;
                    an.SetTrigger("Damage");
                    if (zdravlje <= 0)
                    {
                        
                        an.SetTrigger("Smrt");
                        Instantiate(coin, transform.position+(Vector3.up*1.5f), Quaternion.identity);
                        mumija.Stop();
                        if (!mumija.isPlaying)
                        {
                            mumija.PlayOneShot(smrt);
                        }
                        GameObject.Destroy(gameObject,5f);

                    }
                   
                }
            }
         
        }   else
        {
            agent.SetDestination(transform.position);
        }
        
        IEnumerator ChangeAfter2SecondsCoroutine()
        {
            
            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("EndGame");  
        }
       
    }
}
