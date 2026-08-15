using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float minJumpForce = 6f;
    public float jumpForce = 12f;
    public float holdJumpTimer = 0;
    public float maxTimer = 1;
    public bool isJumping = false;
    public float rnuSpeed = 12;
    public bool isRun = false;

    [Header("Jump Physics (ความหน่วง/ความไว)")]
    public float fallMultiplier = 2.5f; // ทำให้ตอนร่วงตกลงมาเร็วขึ้น (ไม่ลอยคว้าง)
    public float jumpMultiplier = 2f; // ทำให้กระโดดเตี้ยได้ ถ้าปล่อยปุ่มเร็ว
   
    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    public float horizontalInput;
    private bool isGrounded;

    public Vector2 movement = Vector2.zero;

    private bool isLookRight = true;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FilpSprite()
    {
        if(isLookRight && horizontalInput < 0 || !isLookRight && horizontalInput > 0)
        {
            isLookRight = !isLookRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
        }



    }


    public void Animation()
    {
        if (horizontalInput != 0)
        {
            if(isRun)
            {
                animator.SetBool("IsRun", true);
            }
            else
            {
                animator.SetBool("IsRun", false);
                animator.SetBool("IsWalk", true);
            }
            
        }
        else
        {
           
                animator.SetBool("IsWalk", false);
                animator.SetBool("IsRun", false);
            
          
        }
    }


    void Update()
    {
       
        horizontalInput = Input.GetAxisRaw("Horizontal");



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Vector2 target = new Vector2(rb.velocity.x, jumpForce);
            // movenent = Vector2.Lerp(movenent, target, moveMultiplier);
            rb.velocity = new Vector2(rb.velocity.x, minJumpForce);
            isJumping = true;
            holdJumpTimer = 0;

        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            holdJumpTimer += Time.deltaTime;

            if(holdJumpTimer < 0.4)
            {
                float currentJumpForce = Mathf.Lerp(minJumpForce, jumpForce, holdJumpTimer / 1);
                rb.velocity = new Vector2(rb.velocity.x, currentJumpForce);
            }
            else
            {
                isJumping = false;
            }
        }


        if (rb.velocity.y < 0)
        {
            //   Vector2 target = Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            //   movenent = Vector2.Lerp(movenent, target, moveMultiplier);

            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0)
        {
            //Vector2 target = Vector2.up * Physics2D.gravity.y * (jumpMultiplier - 1) * Time.deltaTime;
            //movenent = Vector2.Lerp(movenent, target, moveMultiplier);



            rb.velocity += Vector2.up * Physics2D.gravity.y * (jumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(horizontalInput * rnuSpeed , rb.velocity.y);
            isRun = true;
        }
        else
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed , rb.velocity.y);
            isRun = false;
        }




        FilpSprite();
        Animation();
    }

    void FixedUpdate()
    {
        // 4. เช็คพื้น
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // 5. สั่งให้เดิน (กำหนดค่า Velocity แกน X ตรงๆ ทำให้ไม่ลื่นเป็นน้ำแข็ง)
       
    }
}
