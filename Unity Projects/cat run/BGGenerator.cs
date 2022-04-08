using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGGenerator : MonoBehaviour
{
    public GameObject bg;
    public float span;
    public float startPos;
    float delta = 0;

    private void Start(){
        GameObject background = Instantiate(bg) as GameObject;
        background.transform.position = new Vector3(startPos, bg.transform.position.y, bg.transform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject background = Instantiate(bg) as GameObject;
            background.transform.position = new Vector3(startPos, bg.transform.position.y, bg.transform.position.z);
        }
    }
}