using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Rigidbody2D rigid2d;

    private void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    private void Update()
    {
        rigid.AddForce(transform.left * 5);

        if(transform.position.x < -5.0f)
        {
            Destroy(gameObject);
        }
    }

    //check for collision with player
    void OnCollisionEnter2D(Collision2D other) {
        if(other == player){
            health--;
        }
    }
}
