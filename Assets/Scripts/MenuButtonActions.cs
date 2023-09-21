using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonActions : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject teleportPoints;
    public GameObject roamingModeObjects;
    public GameObject interactText;
    public GameObject exploreButton;
    public GameObject tackleButton;
    // Start is called before the first frame update
    public void StartRoaryTackle()
    { 
        gameManager.StartRoaryTackle();
    }

    public void StartRoam()
    {
        exploreButton.SetActive(false);
        tackleButton.SetActive(false);
        teleportPoints.SetActive(true);
        interactText.SetActive(true);
        gameManager.StartRoam();
    }
}
