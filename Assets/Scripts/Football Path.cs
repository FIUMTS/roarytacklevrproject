using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballPath : MonoBehaviour
{
    //Import the QuadraticCurve Script
    public QuadraticCurve curve;

    //Have a speed variable
    public float speed;

    private float sampleTime;

    void Start()
    {
        sampleTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        sampleTime += Time.deltaTime * speed;
        transform.position = curve.evaluate(sampleTime);
        transform.forward = curve.evaluate(sampleTime*0.001f) - transform.position;

        if(sampleTime >= 1f)
        {
            Debug.Log("Football destroyed");
            Destroy(gameObject);
        }
    }
}
