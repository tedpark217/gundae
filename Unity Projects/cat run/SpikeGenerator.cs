using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;
    float span = 2.0f;
    float delta = 0;

    // Update is called once per frame
    private void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject spikes = Instantiate(spike) as GameObject;
            spikes.transform.position = new Vector3(14, -2.06f, -5);
        }
    }
}