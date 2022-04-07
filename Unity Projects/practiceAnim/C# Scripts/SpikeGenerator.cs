using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject SpikePrefab;
    float span = 1.0f;
    float delta = 0;

    // Update is called once per frame
    private void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject spike = Instantiate(SpikePrefab) as GameObject;
            spike.transform.position = new Vector3(8, -2.59f, 0);
        }
    }
}