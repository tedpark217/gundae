using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundLayer;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
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
        }
    }

    private bool CheckGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}