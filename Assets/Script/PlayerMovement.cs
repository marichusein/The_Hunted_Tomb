using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaznaKlasa
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float walkSpeed;
    [SerializeField] public float runSpeed;
   // public int zdravlje = 5;
    //public int coins=0;
    [SerializeField] private AudioSource mac;
    [SerializeField] private AudioSource kretanje;

    [SerializeField] private AudioClip mac2;
    [SerializeField] private AudioClip hodanje;
    [SerializeField] private AudioClip trcanje;

    private int brojac = 20;
    public int udarac = 1;
    public bool shopOtvoren = false;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    private CharacterController controller;
    public Animator anim;

    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject scena;
    public bool prikaz;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        prikaz = false;
        shop.SetActive(prikaz);
        scena.SetActive(!prikaz);
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
            shopOtvoren = true;

        }
    }

    private void Move()
    {
        Console.WriteLine(brojac);

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
        if (brojac <= 20)
        {
            brojac+=2;
        }
        anim.SetFloat("Speed",0,0.1f,Time.deltaTime);
        
    }
    
    private void Walk()
    {
        if (brojac <= 20)
        {
            brojac++;
        }
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed",0.5f,0.1f,Time.deltaTime);
        Console.WriteLine(brojac);
        if (!kretanje.isPlaying)
        {
            kretanje.PlayOneShot(hodanje, 0.2f);
        }

    }
    
    private void Run()
    {
        Console.WriteLine(brojac);

        if (brojac > 0)
        {
            moveSpeed = runSpeed;
            anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
            brojac--;
        }
        if (!kretanje.isPlaying)
        {
            kretanje.PlayOneShot(trcanje, 0.2f);
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
        mac.PlayOneShot(mac2);
        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"),0);

    }
}
