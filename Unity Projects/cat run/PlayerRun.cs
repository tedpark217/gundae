using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundLayer;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    AudioSource jumpSound;

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        jumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update(){
        if(Input.GetKey(KeyCode.Space))
        {
            Jump();
        }   
    }

    void Jump()
    {
        if(CheckGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpSound.Play();
        }
    }

    private bool CheckGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}