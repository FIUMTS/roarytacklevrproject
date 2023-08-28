using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBillboard : MonoBehaviour
{
    //Responsible for making the circle around the football constantly look at the player no matter the position of the player

    //Camera of the player
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
