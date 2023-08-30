using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Data;
using static UnityEngine.UISystemProfilerApi;
using System.Security.Cryptography;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] roaries;                //an array to hold all the roary GameObjects

    public GameObject footballEndpoint;         //endpoint of the arc path that football follows
    public GameObject footballEndPaths;         //object containing all the possible end paths that the football can end at
    public GameObject deanMesh;                 //ecv of dean schriner
    public GameObject catcherRoary;             //catcher roary GameObject
    public GameObject football;

    private EvercoastPlayer ecPlayer;           //ecv player of dean schriner

    public TextMeshProUGUI introText;           //text above the arena display

    public QuadraticCurve curve;                //Import the QuadraticCurve Script
    public float speed;                         //Have a speed variable

    public bool catcherTackled;                 //bool that checks if the roary has been tackled or touched by the player.
    public bool catcherCaughtFootball;          //bool that checks if catcher caught the ball/player failed to catch the ball
    public bool ballThrown;

    private float sampleTime;


    void Start()
    {
        Debug.Log("Start function is running");

        int randomInt = Random.Range(0, 10);

        ballThrown = false;
        catcherTackled = false;
        catcherCaughtFootball = false;

        ecPlayer = deanMesh.GetComponent<EvercoastPlayer>();
        catcherRoary = roaries[randomInt]; //assigns random roary to be catcher roary
        catcherRoary.tag = "Catcher"; 
        footballEndpoint.transform.position = footballEndPaths.transform.GetChild(randomInt).position; //assigns endpoint relating to randomly assigned roary to be the endpoint that the football arc follows
        sampleTime = 0f;
        Time.timeScale = 0; //freeze/pause game on load
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
            introText.text = "Roary caught the ball!\nPress Right Trigger to try again.";
        }

        if(ballThrown)
        {
            Debug.Log("This should be called");
            ThrowBall();
        }
    }

    public void StartGame(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //If the time is frozen, unfreeze time (aka start the game)
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1.0f;      //Resume time
            introText.text = "Tackle Roary before he catches the football!";

            //ecPlayer.Seek(0f);
            ecPlayer.Play();            //Play dean schriner ecv

            StartTimers();              //start any timers set up in the GameManager
        }
    }

    public void ReloadScene(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Loader.Reload();
        Debug.Log("Scene reloaded.");
    }

    public void Turn(GameObject obj, float degrees)
    {
        obj.transform.Rotate(0, degrees, 0);
    }

    public void StartTimers()
    {
        Debug.Log("Timers started");
        FunctionTimer.Create(() => SetThrowBallTrue(), 1.9f);
        //FunctionTimer.Create(() => Turn(catcherRoary, 35), 5);
        //FunctionTimer.Create(() => Turn(catcherRoary, -35), 10);
    }

    public void SetThrowBallTrue()
    {
        ballThrown = true;
        if(ballThrown)
        {
            Debug.Log("ballThrown should be true");
        }
    }

    public void LoadNextScene()
    {
        //TO DO - Replace SceneManager below with Loader.Load() to load the next scene.
        Loader.Load(Loader.Scene.Level1);
    }

    public void ThrowBall()
    {
        Debug.Log("ThrowBall Entered");

        sampleTime += Time.deltaTime * speed;
        Debug.Log(sampleTime);
        football.transform.position = curve.evaluate(sampleTime);
        football.transform.forward = curve.evaluate(sampleTime * 0.001f) - football.transform.position;

        if (sampleTime >= 1f)
        {
            Debug.Log("Football destroyed");
            ballThrown = false;
            Destroy(football);
            sampleTime = 0f;
        }
    }
}
