using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShifter : MonoBehaviour
{
    public float shiftSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        //move bg left with given speed
        transform.Translate(Vector3.left * shiftSpeed * Time.deltaTime);

        //destroy if out of camera
        if(transform.position.x < -19.0f)
        {
            Destroy(gameObject);
        }
    }
}
