using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera cam1, cam2;
    public Vector3 originalPos1, originalPos2;
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        SaveCamPositions();
    }

    // Update is called once per frame
    public void Switch()
    {
        cam1.enabled = !cam1.enabled;
        //Debug.Log("AfterSwitch1: " + originalPos1.ToString());
        cam1.transform.position = originalPos1;
        cam2.enabled = !cam2.enabled;
        //Debug.Log("AfterSwitch2: " + originalPos2.ToString());
        cam2.transform.position = originalPos2;

    }
    public void SaveCamPositions()
    {
        originalPos1 = cam1.transform.position;
        originalPos2 = cam2.transform.position;
        //Debug.Log("PreSwitch1: " + originalPos1.ToString());
        //Debug.Log("PreSwitch2: " + originalPos2.ToString());
    }
}
