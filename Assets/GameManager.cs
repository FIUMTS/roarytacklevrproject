using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] roaries;
    public GameObject footballEndpoint;
    public GameObject footballEndPaths;

    private GameObject catcherRoary;
    //private Transform footballEndpoint;

    public TextMeshProUGUI introText;

    public bool catcherTackled = false;
    public bool catcherCaughtFootball = false;

    void Start()
    {
        int randomInt = Random.Range(0, 10);

        catcherRoary = roaries[randomInt];
        catcherRoary.tag = "Catcher";
        footballEndpoint.transform.position = footballEndPaths.transform.GetChild(randomInt).position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(catcherTackled)
        {
            introText.text = "You win!";
        }
        else if(catcherCaughtFootball)
        {
            introText.text = "Roary caught the ball!";
        }
    }
}
