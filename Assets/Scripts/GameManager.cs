using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Data;
using static UnityEngine.UISystemProfilerApi;
using System.Security.Cryptography;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] roaries;                //an array to hold all the roary GameObjects

    public GameObject footballEndpoint;         //endpoint of the arc path that football follows
    public GameObject footballEndPaths;         //object containing all the possible end paths that the football can end at
    public GameObject deanMesh;                 //ecv of dean schriner
    public GameObject catcherRoary;             //catcher roary GameObject
    public GameObject football;                 //football gameobject
    public GameObject player;                   //player gameobject

    private Animator catcherAnimator;           //Animator for roary

    public TextMeshProUGUI introText;           //Text on top of stadium

    private EvercoastPlayer ecPlayer;           //ecv player of dean schriner

    public QuadraticCurve curve;                //Import the QuadraticCurve Script
    public float speed;                         //Have a speed variable

    public bool catcherTackled;                 //bool that checks if the roary has been tackled or touched by the player.
    public bool catcherCaughtFootball;          //bool that checks if catcher caught the ball/player failed to catch the ball
    private bool ballThrown;                    //bool that checks if football has been thrown
    public bool isPaused;                       //bool to check if game is paused in beginning

    //private int level = 0;                      //int taht indicates difficulty level

    public GameObject roaryTackleGameObjects;   //all game objects associated with the Roary Tackle game


    private float sampleTime;


    void Start()        //Setting variables at startup
    {
        Debug.Log("Start function is running");


    }

    public void StartRoaryTackle()
    {

        roaryTackleGameObjects.SetActive(true);
        player.transform.position = new Vector3(58.54f, 0.05f, -7.46f);
        player.transform.Rotate(0, -90, 0);

        int randomInt = Random.Range(0, 10);

        ballThrown = false;
        catcherTackled = false;
        catcherCaughtFootball = false;
        isPaused = true;

        ecPlayer = deanMesh.GetComponent<EvercoastPlayer>();
        catcherRoary = roaries[randomInt]; //assigns random roary to be catcher roary
        catcherRoary.tag = "Catcher"; 
        footballEndpoint.transform.position = footballEndPaths.transform.GetChild(randomInt).position; //assigns endpoint relating to randomly assigned roary to be the endpoint that the football arc follows
        catcherAnimator = catcherRoary.GetComponent<Animator>();
        sampleTime = 0f;
        Time.timeScale = 0; //freeze/pause game on load
        if(isPaused)
        {
            Debug.Log("Game is paused.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ballThrown)
        {
           // Debug.Log("This should be called");
            ThrowBall();
        }
    }

    public void StartGame(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //If the time is frozen, unfreeze time (aka start the game)
        if (isPaused)
        {
            isPaused = false;
            Debug.Log("No longer paused");
            Time.timeScale = 1.0f;      //Resume time
            introText.text = "Tackle Roary before he catches the football!";

            //ecPlayer.Seek(0f);
            ecPlayer.Play();            //Play dean schriner ecv

            StartTimers();              //start any timers set up in the GameManager
        }
    }



    public void Turn(GameObject obj, float degrees)
    {
        obj.transform.Rotate(0, degrees, 0);
    }

    public void StartTimers()
    {
        FunctionTimer.Create(() => SetThrowBallTrue(), 1.9f);
        FunctionTimer.Create(() => TurnRoaryHead(), 8f);
    }

    private void TurnRoaryHead()
    {
        catcherAnimator.SetBool("turnHead", true);
    }

    public void SetThrowBallTrue()
    {
        ballThrown = true;
        if(ballThrown)
        {
            Debug.Log("ballThrown should be true");
        }
    }
    
    public void ReloadScene(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Loader.Reload();
        Debug.Log("Scene reloaded.");
    }

    public void LoadNextScene(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //TO DO - Replace SceneManager below with Loader.Load() to load the next scene.
        Debug.Log("LoadNextScene entered");
        switch(Loader.GetCurrentLevel())
        {
            case ("Level1"):
                Loader.Load(Loader.Scene.Level2);
                break;
            case ("Level2"):
                Loader.Load(Loader.Scene.Level3);
                break;
            default:
                Loader.Load(Loader.Scene.Level1);
                break;
        }
    }

    public void ThrowBall()
    {
        //Debug.Log("ThrowBall Entered");
        football.SetActive(true);
        sampleTime += Time.deltaTime * speed;
        //Debug.Log(sampleTime);
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
