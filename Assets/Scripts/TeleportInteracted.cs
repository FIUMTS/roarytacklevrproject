using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInteracted : MonoBehaviour
{
    
    private Animator animator;
    // Start is called before the first frame update

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interacted()
    {
        animator.SetTrigger("Interacted");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
