using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Vector3 originalPos1, originalPos2;
    void Start()
    {
        originalPos1 = cam1.transform.position;
        originalPos2 = cam2.transform.position;

        cam1.enabled = true;
        cam2.enabled = false;
    }

    // Update is called once per frame
    public void Switch()
    {
        cam1.enabled = !cam1.enabled;
        cam1.transform.position = originalPos1;
        cam2.enabled = !cam2.enabled;
        cam2.transform.position = originalPos2;
    }
}
