using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float extraJump;
    [SerializeField] LayerMask groundLayer;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;
    private Animator animator;

    private float jumpNum;
    private bool isGrounded;
    private float jumpCoolDown;

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        animator = GetComponent<Animator>();

        jumpNum = 0;
    }

    // Update is called once per frame
    private void Update(){
        float horizontalMove = Input.GetAxisRaw("Horizontal");

        //flip character
        Flip(horizontalMove);

        //move player
        Move(horizontalMove);

        //jump
        if(Input.GetKey(KeyCode.Space))
        {
            Jump();
        }   

        CheckGrounded();
    }

    void Flip(float horiMove)
    {
        if(horiMove == 1){
            transform.localScale = new Vector3(-1,1,1);
        }
        else if(horiMove == -1){
            transform.localScale = new Vector3(1,1,1);
        }
    }

    void Move(float horiMove)
    {
        body.velocity = new Vector2(horiMove * speed, body.velocity.y);

        //for horizontal movement animation (updating speed variable)
        animator.SetFloat("speed", Mathf.Abs(horiMove));
    }

    void Jump()
    {
        if(isGrounded || jumpNum < extraJump)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpNum++; 
        }
        animator.SetBool("isJumping", true);
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void CheckGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        if(raycastHit.collider != null)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
            jumpNum = 0;
            jumpCoolDown = Time.time + 0.2f;
        } else if (Time.time < jumpCoolDown)
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
    }
}