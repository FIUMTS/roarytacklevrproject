using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBillboard : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera mainCam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(mainCam.transform);
        transform.Rotate(0, 180, 0);
    }
}
