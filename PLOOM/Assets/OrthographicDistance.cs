using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicDistance : MonoBehaviour
{
    public float fbreite, flaenge;
    public new Camera camera;
    public float sensitivityX, sensitivityY;
    // Start is called before the first frame update
    void Start()
    {
        fbreite = GlobalControl.Instance.raumbreite;
        flaenge = GlobalControl.Instance.raumlaenge;
        camera = GameObject.Find("2DCamera").GetComponent<Camera>();
        DistanzAnpassen();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && GlobalControl.Instance.toggle == true)
        {
            sensitivityX = 1.5f;
            sensitivityY = 1.5f;
            camera.transform.position -= camera.transform.right * Input.GetAxis("Mouse X") * sensitivityX;
            camera.transform.position -= camera.transform.up * Input.GetAxis("Mouse Y") * sensitivityY;
        }
    }

    public void DistanzAnpassen()
    {
        if (fbreite >= flaenge)
        {
            camera.orthographicSize = fbreite * 0.5f;
        }
        else
        {
            camera.orthographicSize = flaenge * 0.75f;
        }
    }
}
