using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParade : MonoBehaviour
{
    public GameObject parade;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            parade.SetActive(true);
        }
    }

}
