using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class ControllerBindings : MonoBehaviour
{

    private ActionBasedController controller; //Controller input
    public InputActionReference speedShift;
    public LocomotionSystem locomotionSystem;
    private ActionBasedContinuousMoveProvider controllerContinuousMoveProvider;
    //public TextMeshProUGUI introText;         //Text above the large screen of arena
    public GameManager gameManager;           //GameManager object

    public float speed;
    public float shiftSpeed;

    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        controller.activateAction.action.performed += StartGame; //StartGame is executed when right trigger is pressed (right trigger is "activateAction" in InputActionAsset)
        speedShift.action.performed += SpeedupShift;
        speedShift.action.canceled += SlowdownShift;
        controllerContinuousMoveProvider = locomotionSystem.GetComponent<ActionBasedContinuousMoveProvider>();
    }

    //StartGame is executed when player presses the right trigger to start the game
    private void StartGame(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //gameManager.isPaused = false;
        gameManager.StartGame(obj);
    }

    private void SpeedupShift(InputAction.CallbackContext ctx)
    {
        controllerContinuousMoveProvider.moveSpeed = shiftSpeed;
    }

    private void SlowdownShift(InputAction.CallbackContext ctx)
    {
        controllerContinuousMoveProvider.moveSpeed = speed;
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

    private void LoadNextScene(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        controller.activateAction.action.performed -= LoadNextScene;
        controller.activateAction.action.performed += StartGame;
        gameManager.LoadNextScene(obj);
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
        controller.activateAction.action.performed += LoadNextScene; //Remove ReloadScene callback

    }
}
