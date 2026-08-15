using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float playerSpeed = 5;
    public Animator animator;
    public float JumpPower = 5;

    public float horizontal = 0;
    public float vertical = 0;
    public bool characterLookRight = true;
    public Vector2 moveVelocity;

    public float mutiply;


    public float AC = 5;
    // Start is called before the first frame update



    public void Animation()
    {
        //if(movement.x != 0)
        //{
        //    animator.SetBool("IsWalk", true);
        //}
        //else
        //{
        //    animator.SetBool("IsWalk", false);
        //}
    }


    public void Flip()
    {
       //if(characterLookRight && movement.x <0 || !characterLookRight && movement.x > 0)
       // {
       //     characterLookRight = !characterLookRight;
       //     Vector3 localScale = player.transform.localScale;
       //     localScale.x *= -1;
       //     player.transform.localScale = localScale; 
       // }




    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        horizontal = Input.GetAxisRaw("Horizontal");



        // vertical = rb.velocity.y;

        Vector2 targetMoveX = new Vector2(horizontal * playerSpeed,0) * Time.deltaTime;

        moveVelocity = Vector2.Lerp(moveVelocity, targetMoveX, AC);


        if (Input.GetKeyDown(KeyCode.Space)) 
         {
            //float target = 0;
            //targetVertical = JumpPower;
            //vertical += JumpPower;
        }


       

        rb.velocity = new Vector2(moveVelocity.x, moveVelocity.y);

        Flip();
        Animation();
    }

    private void FixedUpdate()
    {
       
    }
}
