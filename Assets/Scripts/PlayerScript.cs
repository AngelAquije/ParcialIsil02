using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : PlayerMain
{
    void Start()
    {
        
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            ani.SetBool("Jump", true);
            jump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }

        ani.SetFloat("yVelocity", rb.velocity.y);
    }

    private void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, jump);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death")) 
        {
            SceneManager.LoadScene(0);
        }
    }
}
