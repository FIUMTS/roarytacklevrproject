using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;


public class Collision : MonoBehaviour
{
    private Animator animator;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && CompareTag("Catcher"))
        {
            animator.speed = 0;
            Debug.Log("COLLISION with catcher!");
            gameManager.catcherTackled = true;

        }
        else
        {
            Debug.Log("COLLISION, but not catcher");
        }
    }

}
