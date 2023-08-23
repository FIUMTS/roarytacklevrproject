using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerBindings : MonoBehaviour
{
    private ActionBasedController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();

        controller.activateAction.action.performed += StartGame;

    }

    private void StartGame(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
