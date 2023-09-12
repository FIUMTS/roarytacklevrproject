using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;


public class Collision : MonoBehaviour
{
    private Animator animator;
    public ControllerBindings controllerBindings;
    public TextMeshProUGUI introText;           //text above the arena display
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controllerBindings = controllerBindings.GetComponent<ControllerBindings>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && CompareTag("Catcher"))
        {
            //animator.speed = 0;
            animator.SetBool("roaryTackled", true);
            Debug.Log("COLLISION WITH CATCHER!");
            introText.text = "You tackled Roary!\nPress Right Trigger to return to main menu.";
            controllerBindings.SetTriggerToReload();
            gameManager.catcherTackled = true;
            tag = "Roary";

        }
        else if (other.CompareTag("Player") && CompareTag("Roary"))
        {
            Debug.Log("COLLISION, but not catcher");
        }
    }


}
