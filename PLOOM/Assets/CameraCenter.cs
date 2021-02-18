using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    public float fbreite, flaenge;
    public Camera cam1, cam2;
    public Light dir1, dir2;
    void Start()
    {
        fbreite = GlobalControl.Instance.raumbreite;
        flaenge = GlobalControl.Instance.raumlaenge;
        gameObject.transform.position = new Vector3(fbreite / 2, 0, flaenge / 2);
        cam2.transform.position = new Vector3(fbreite / 2, fbreite + flaenge, flaenge / 2);
        dir2.transform.position = cam2.transform.position;
        if (fbreite >= flaenge)
        {
            cam1.transform.position = new Vector3(cam1.transform.position.x, fbreite, cam1.transform.position.z);
            dir1.transform.position = cam1.transform.position;
        }
        else
        {
            cam1.transform.position = new Vector3(cam1.transform.position.x, flaenge, cam1.transform.position.z);
            dir1.transform.position = cam1.transform.position;
        }
    }
}
