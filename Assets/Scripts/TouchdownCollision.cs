using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TouchdownCollision : MonoBehaviour
{
    private Animator animator;
    public TextMeshProUGUI introText;           //text above the arena display
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
            if(!gameManager.catcherTackled)
            {
                introText.text = "Roary caught the ball!\nPress Right Trigger to try again.";
            }
            Debug.Log("Roary has reached the end");
            gameManager.catcherCaughtFootball = true;
            other.gameObject.SetActive(false);
        }
    }

}
