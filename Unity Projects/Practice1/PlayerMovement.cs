using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider;


    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update(){
        float horizontalMove = Input.GetAxisRaw("Horizontal");

        //flip character
        if(horizontalMove == 1){
            transform.localScale = new Vector3(-0.5f,0.5f,0.5f);
        }
        else if(horizontalMove == -1){
            transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        }

        //move player
        body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, body.velocity.y);

        //jump
        if(Input.GetKey(KeyCode.Space) && isGrounded()) {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }

        //for animation movement
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
    }

    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
