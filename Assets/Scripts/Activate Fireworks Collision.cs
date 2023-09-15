using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFireworksCollision : MonoBehaviour
{
    public GameObject firework;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        { firework.SetActive(true); }
    }
}
