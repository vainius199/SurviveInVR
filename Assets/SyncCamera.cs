using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncCamera : MonoBehaviour
{
    public Camera MainCam;

    void LateUpdate()
    {
         transform.rotation = MainCam.transform.rotation;
         transform.position = MainCam.transform.position;
    }

}
