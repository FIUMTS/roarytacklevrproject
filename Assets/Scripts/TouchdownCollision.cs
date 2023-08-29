using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchdownCollision : MonoBehaviour
{
    private Animator animator;

    public GameManager gameManager;

    public ControllerBindings controllerBindings;
    // Start is called before the first frame update
    void Start()
    {
        controllerBindings = controllerBindings.GetComponent<ControllerBindings>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Catcher"))
        {
            other.gameObject.SetActive(false);
            controllerBindings.SetTriggerToReload();
            
        }
        else if (other.CompareTag("Roary"))
        {
            Debug.Log("Roary has reached the end");
            other.gameObject.SetActive(false);
            gameManager.catcherCaughtFootball = true;
        }
    }

}
