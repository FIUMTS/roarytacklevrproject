using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject player;
    public GameObject fieldPos;
    public GameObject suitePos;


    public void TeleportToField()
    {
        player.transform.Rotate(0, -180, 0);
        player.transform.position = fieldPos.transform.position;
    }
    
    public void TeleportToSuites()
    {
        player.transform.Rotate(0, -90, 0);
        player.transform.position = suitePos.transform.position;
    }
}
