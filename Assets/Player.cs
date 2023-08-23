using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    public LocomotionSystem locomotionSystem;
    private ActionBasedContinuousMoveProvider abcmp;

    // Start is called before the first frame update
    void Start()
    {
        abcmp = locomotionSystem.GetComponent<ActionBasedContinuousMoveProvider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
