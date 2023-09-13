using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonActions : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject teleportPoints;
    // Start is called before the first frame update
    public void StartRoaryTackle()
        { gameManager.StartRoaryTackle(); }

    public void StartRoam()
    {
        teleportPoints.SetActive(true);
        gameManager.StartRoam();
    }
}
