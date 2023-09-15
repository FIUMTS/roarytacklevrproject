using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCollide : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Parade") && CompareTag("TurnCollider"))
        {
            //Debug.Log("Collision happened");
            other.transform.Rotate(0, 45, 0);
        }
        else if (other.CompareTag("Parade") && CompareTag("TurnCollider2"))
        {
            //Debug.Log("Collision happened");
            other.transform.Rotate(0, -45, 0);
        }
        else if (other.CompareTag("Parade") && CompareTag("DeleteParadeObject"))
        {
            //Debug.Log("Collision happened");
            Destroy(other.gameObject);
        }
    }
}
