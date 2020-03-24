using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;

public class GhostOrbBehavior : MonoBehaviour
{
   
    float amplitude = .1f;
    float frequencyX, frequencyY;

    // Start is called before the first frame update
    void Start()
    {
       // transform.position = orbContainer.position;
    }

    // Update is called once per frame
    void Update()
    {
        FloatMovement(); 
    }

    private void FloatMovement()
    {
        frequencyX = 1f;
        frequencyY = 2f;

        float x = Mathf.Cos(Time.time * frequencyX) * amplitude;
        float y = Mathf.Sin(Time.time * frequencyY) * amplitude;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);

    }
}
