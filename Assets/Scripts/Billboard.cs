using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] BillboardType billboardType;
    public enum BillboardType { LookAtCamera, CameraForward };

    public Camera mainCam;

    private void LateUpdate()
    {
        switch (billboardType)
        {
            case BillboardType.LookAtCamera:
                transform.LookAt(mainCam.transform.position, Vector3.up);
                transform.Rotate(90, 0, 0);
                break;
            case BillboardType.CameraForward:
                transform.forward = mainCam.transform.forward;
                break;
            default:

                break;
        }
    }



}
