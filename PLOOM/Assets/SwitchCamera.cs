using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera cam1, cam2;
    public Light dirLight1, dirLight2;
    public Vector3 originalPos1, originalPos2, originaldirLight1, originaldirLight2;
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
        dirLight1.enabled = !dirLight1.enabled;
        cam2.enabled = !cam2.enabled;
        //Debug.Log("AfterSwitch2: " + originalPos2.ToString());
        cam2.transform.position = originalPos2;
        dirLight2.enabled = !dirLight2.enabled;
        if (cam1.enabled == true)
        {
            dirLight1.enabled = false;
            dirLight2.enabled = true;
        }
        else
        {
            dirLight1.enabled = true;
            dirLight2.enabled = false;
        }

    }
    public void SaveCamPositions()
    {
        originalPos1 = cam1.transform.position;
        originalPos2 = cam2.transform.position;
        //Debug.Log("PreSwitch1: " + originalPos1.ToString());
        //Debug.Log("PreSwitch2: " + originalPos2.ToString());
    }
}
