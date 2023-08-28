using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerBindings : MonoBehaviour
{

    private ActionBasedController controller; //Controller input
    public TextMeshProUGUI introText;         //Text above the large screen of arena
    public GameManager gameManager;           //GameManager object
    public GameObject deanMesh;               //ecv of dean schriner
    private EvercoastPlayer ecPlayer;         //ecv player of dean schriner

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        ecPlayer = deanMesh.GetComponent<EvercoastPlayer>();
        controller.activateAction.action.performed += StartGame; //StartGame is executed when right trigger is pressed (right trigger is "activateAction" in InputActionAsset)

    }

    //StartGame is executed when player presses the right trigger to start the game
    private void StartGame(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //If the time is frozen, unfreeze time (aka start the game)
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1.0f;      //Resume time
            introText.text = "Tackle Roary before he catches the football!";
            ecPlayer.Play();            //Play dean schriner ecv

            gameManager.StartTimers(); //start any timers set up in the GameManager
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(gameManager.catcherTackled == true)
        {
            controller.activateAction.action.performed += ReloadScene; //Replace the StartGame action on right trigger to ReloadScene
            gameManager.catcherTackled = false;
            
        }
    }


    private void ReloadScene(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        controller.activateAction.action.performed -= ReloadScene; //Replace the StartGame action on right trigger to ReloadScene
        controller.activateAction.action.performed += StartGame;   //Replace ReloadGame with StartGame upon reload
        Loader.Load(Loader.Scene.Level1);
        Debug.Log("Scene reloaded.");
    }
}
