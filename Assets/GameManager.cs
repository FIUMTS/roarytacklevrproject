using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Data;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] roaries;                //an array to hold all the roary GameObjects
    public GameObject footballEndpoint;         //endpoint of the arc path that football follows
    public GameObject footballEndPaths;         //object containing all the possible end paths that the football can end at

    public GameObject catcherRoary;             //catcher GameObject


    public TextMeshProUGUI introText;           //text above the arena display

    public bool catcherTackled = false;         //Bool that checks if the roary has been tackled or touched by the player.
    public bool catcherCaughtFootball = false;  //Bool that checks if catcher caught the ball/player failed to catch the ball


    void Start()
    {
        int randomInt = Random.Range(0, 10);

        catcherRoary = roaries[randomInt]; //assigns random roary to be catcher roary
        catcherRoary.tag = "Catcher"; 
        footballEndpoint.transform.position = footballEndPaths.transform.GetChild(randomInt).position; //assigns endpoint relating to randomly assigned roary to be the endpoint that the football arc follows

        Time.timeScale = 0; //freeze/pause game on load


        //FunctionTimer.StopTimer("Second Turn");
    }

    // Update is called once per frame
    void Update()
    {

        if(catcherTackled)
        {
            introText.text = "You tackled Roary!\nPress Right Trigger to move onto the next level.";

        }
        else if(catcherCaughtFootball)
        {
            introText.text = "Roary caught the ball!";
        }
    }

    public void Turn(GameObject obj, float degrees)
    {
        obj.transform.Rotate(0, degrees, 0);
    }

    public void StartTimers()
    {
        //FunctionTimer.Create(() => Turn(catcherRoary, 35), 5);
        //FunctionTimer.Create(() => Turn(catcherRoary, -35), 10);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
