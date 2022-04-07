using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D body;
    GameObject player;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();   
        this.player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    private void Update()
    {
        body.AddForce(Vector3.left * moveSpeed);

        if(transform.position.x < -10.0f)
        {
            Destroy(gameObject);
        }
    }

    //check for collision with player
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("collision!");
    }
}