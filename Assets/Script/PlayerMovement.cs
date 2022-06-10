using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaznaKlasa
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float walkSpeed;
    [SerializeField] public float runSpeed;
    public int udarac=1;

    [SerializeField] private AudioSource igrac1;
    [SerializeField] private AudioSource igrac2;
    
    [SerializeField] private AudioClip mac;
    [SerializeField] private AudioClip hodanje;
    [SerializeField] private AudioClip trcanje;



   //public int zdravlje = 5000;
    //public int coins=0;
    

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    private CharacterController controller;
    public Animator anim;

    [SerializeField] public GameObject shop;
    [SerializeField] public GameObject scena;
    //[SerializeField] public GameObject lvl2;

    public bool prikaz;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        prikaz = false;
        shop.SetActive(prikaz);
        scena.SetActive(!prikaz);
        //lvl2.SetActive(false);
    }

    private void Update()
    {
        if (zdravlje != 0)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
            
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Cursor.lockState = CursorLockMode.None;
            shop.SetActive(true);
            scena.SetActive(false);
        }
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();

            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }
            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump(); 
            }
        }

            
        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed",0,0.1f,Time.deltaTime);
         igrac1.Stop();
    }
    
    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed",0.5f,0.1f,Time.deltaTime);
        if (!igrac1.isPlaying)
        {
            igrac1.PlayOneShot(hodanje,0.5f);
        }
    }
    
    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed",1,0.1f,Time.deltaTime);
        if (!igrac1.isPlaying)
        {
            igrac1.PlayOneShot(trcanje,0.3f);
        }

    }
    
    private void Jump()
    {

        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private IEnumerator Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"),1);
        anim.SetTrigger("Attack");
        if (!igrac2.isPlaying)
        {
            igrac2.PlayOneShot(mac,0.2f);
        }

        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"),0);
      
    }
}
