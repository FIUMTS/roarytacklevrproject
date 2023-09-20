using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject player;
    public GameObject fieldPos;
    public GameObject suitePos;
    Vector3 menuStartPos;


    private Animator animator;

    public void Start()
    {
        menuStartPos = player.transform.position;
    }

    public void TeleportToField()
    {
        player.transform.Rotate(0, -90, 0);
        player.transform.position = fieldPos.transform.position;
    }
    
    public void TeleportToSuites()
    {
        player.transform.Rotate(0, -180, 0);
        player.transform.position = suitePos.transform.position;
    }

    public void TeleportToMenuArea()
    {
        Loader.Reload();
    }

}
