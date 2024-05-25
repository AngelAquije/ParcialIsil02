using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    [Header("Componentes")]
    public Rigidbody2D rb;
    public Animator ani;
    [SerializeField] public Transform groundCheckCollider;
    [SerializeField] public LayerMask groundLayer;

    [Header("PublicFields")]
    [Range(1f,5f)]public float speed = 2;
    [Range(100f,500f)] public float jumpPower = 2;

    [Header("PrivateFields")]
    public float horizontalValue;
    public float runSpeedModifier = 2f;
    public const float groundCheckRadius = 0.2f;

    [Header("Bools")]
    public  bool isGrounded;
    public bool isRunning;
    public bool facingRight = true;
    public bool jump;

    private void Awake()
    {
          
    }

    void Update()
    {     
        
    }
    

    public void GroundCheck() 
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0) 
        {
            isGrounded = true;            
        }
        ani.SetBool("Jump", !isGrounded);
    }

    public void Move(float dir, bool jumpFlag)
    {
        if (isGrounded && jumpFlag) 
        {
            isGrounded = false;
            jumpFlag = false;
            rb.AddForce(new Vector2(0f,jumpPower));
        }
        #region Walk & Run
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;

        if (isRunning) 
        {
            xVal *= runSpeedModifier;
        }
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
            facingRight = false;
        }

        else if (!facingRight && dir > 0) 
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

        ani.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        #endregion
    }

    


}
