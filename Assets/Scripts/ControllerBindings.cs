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

    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        controller.activateAction.action.performed += StartGame; //StartGame is executed when right trigger is pressed (right trigger is "activateAction" in InputActionAsset)
    }

    //StartGame is executed when player presses the right trigger to start the game
    private void StartGame(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //gameManager.isPaused = false;
        gameManager.StartGame(obj);
    }


    // Update is called once per frame
    void Update()
    {

    }


    private void ReloadScene(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //Debug.Log("ReloadScene entered");
        controller.activateAction.action.performed -= ReloadScene; //Remove ReloadScene callback
        controller.activateAction.action.performed += StartGame; //Remove ReloadScene callback
        gameManager.ReloadScene(obj);
    }

    public void SetTriggerToReload()
    {
        //Debug.Log("SetTriggerToReload entered");
        controller.activateAction.action.performed -= StartGame; //Remove ReloadScene callback
        controller.activateAction.action.performed += ReloadScene; //Remove ReloadScene callback
    }

    public void SetTriggerToLoadNext()
    {
       // Debug.Log("SetTriggerToLoadNext entered");
        controller.activateAction.action.performed -= StartGame; //Remove ReloadScene callback
        controller.activateAction.action.performed += ReloadScene; //Remove ReloadScene callback

    }
}
