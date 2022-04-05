using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obPrefab;
    float span = 1.0f;
    float delta = 0;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(obPrefab) as GameObject;
            go.transform.position = new Vector3(right, y, 0);
        }
    }

}
