using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public float playerSpeed = 5;
    public Animator animator;

    public float moveX =0;
    public Vector2 movement;
    // Start is called before the first frame update



    public void Animation()
    {
        if(movement.x != 0)
        {
            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }
    }


    public void Flip()
    {
        if (movement.x > 0 )
        {
           // player.transform.localScale.x * -1;
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }




    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




         moveX = Input.GetAxisRaw("Horizontal");

        movement.x = moveX * playerSpeed * Time.deltaTime;

        player.transform.Translate(movement);



        Animation();
    }
}
