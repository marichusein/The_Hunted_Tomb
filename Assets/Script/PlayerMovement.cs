using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaznaKlasa
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
   // public int zdravlje = 5;
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
            prikaz = !prikaz;
            shop.SetActive(prikaz);
            scena.SetActive(!prikaz);
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
        
    }
    
    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed",0.5f,0.1f,Time.deltaTime);
    }
    
    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed",1,0.1f,Time.deltaTime);

    }
    
    private void Jump()
    {

        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private IEnumerator Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"),1);
        anim.SetTrigger("Attack");

        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"),0);

    }
}
