using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HindernisInputs : MonoBehaviour
{
    private GameObject floor;
    private Vector3 scaleChange;
    private bool _mouseState;
    public Material floormat;
    public Camera kamera;
    public GameObject target;
    public Vector3 screenSpace;
    public Vector3 startPos;
    public float screenSpacex, screenSpacey, screenSpacez;
    public Vector3 offset;
    public Text textXY, textWL;
    public float fbreite, flaenge, fflaeche;
    public float sizingFactor = 0.02f;
    private float startSizeX, startSizeZ;
    public float startX, startZ;

    void Start()
    {
        fbreite = GlobalControl.Instance.raumbreite;
        flaenge = GlobalControl.Instance.raumlaenge;
        fflaeche = GlobalControl.Instance.raumflaeche;
        DrawFloor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.name == "3DCam")
        {
            Transformieren3D();
            Skalieren3D();
        }
        else
        {
            Transformieren();
            Skalieren();
            SetTextAxis(textXY);
            SetTextSize(textWL);
        }

    }

    public void Transformieren()
    {
        // Debug.Log(_mouseState);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = GetClickedObject(out hitInfo);
            if (target != null)
            {
                _mouseState = true;
                screenSpace = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _mouseState = false;
        }
        if (_mouseState)
        {
            //keep track of the mouse position
            var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            //convert the screen mouse position to world point and adjust with offset
            var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

            //update the position of the object in the world
            target.transform.position = curPosition;
            SaveHindernis(target);
        }
    }

    public void Transformieren3D()
    {
        // Debug.Log(_mouseState);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = GetClickedObject(out hitInfo);
            if (target != null)
            {
                startPos = transform.position;
                screenSpace = Camera.main.WorldToScreenPoint(target.transform.position);
                screenSpacex = Input.mousePosition.x - screenSpace.x;
                screenSpacey = Input.mousePosition.y - screenSpace.y;
                screenSpacez = Input.mousePosition.y - screenSpace.y;

                float disX = Input.mousePosition.x - screenSpacex;
                float disZ = Input.mousePosition.z - screenSpacez;
                float disY = Input.mousePosition.y - screenSpacey;

                Vector3 lastPos = Camera.main.ScreenToWorldPoint(new Vector3(disX, disY, disZ));
                transform.position = new Vector3(lastPos.x, startPos.y, lastPos.z);

                SaveHindernis(target);
            }
        }
    }

    public void Skalieren3D()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (target != null)
            {
                float positionZ = 10.0f;
                Vector3 position = new Vector3(Input.mousePosition.x, positionZ, Input.mousePosition.y);
                startX = position.x;
                startZ = position.z;
                position = Camera.main.ScreenToWorldPoint(position);
                startSizeX = target.transform.localScale.z;
                startSizeZ = target.transform.localScale.x;
            }
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 size = target.transform.localScale;
            size.x = startSizeX + (Input.mousePosition.x - startX) * sizingFactor;
            size.z = startSizeZ + (Input.mousePosition.y - startZ) * sizingFactor;
            target.transform.localScale = size;
            SaveHindernis(target);
        }
    }

    public void Skalieren()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (target != null)
            {
                float positionZ = 10.0f;
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionZ);
                startX = position.x;
                startZ = position.z;
                position = Camera.main.ScreenToWorldPoint(position);
                startSizeX = target.transform.localScale.z;
                startSizeZ = target.transform.localScale.x;
            }
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 size = target.transform.localScale;
            size.x = startSizeX + (Input.mousePosition.x - startX) * sizingFactor;
            size.z = startSizeZ + (Input.mousePosition.y - startZ) * sizingFactor;
            target.transform.localScale = size;
            SaveHindernis(target);
        }
    }

    public void SetTextAxis(Text txt)
    {
        if (target != null)
        {
            double myX = System.Math.Round(target.transform.position.x, 2);
            double myZ = System.Math.Round(target.transform.position.z, 2);
            txt.text = ("Hindernis X: " + myX + "\nHindernis Y: " + myZ);
        }
    }

    public void SetTextSize(Text txt)
    {
        if (target != null)
        {
            double myW = System.Math.Round(target.transform.localScale.x, 2);
            double myL = System.Math.Round(target.transform.localScale.z, 2);
            txt.text = ("Hindernis W: " + myW + "\nHindernis L: " + myL);
        }
    }

    public void DrawFloor()
    {
        floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.transform.position = new Vector3((fbreite / 2), 0, (flaenge / 2));
        floor.GetComponent<Renderer>().material = floormat;
        scaleChange = new Vector3(fbreite, 0.2f, flaenge);
        floor.transform.localScale = scaleChange;
        floor.GetComponent<BoxCollider>().enabled = false;
    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }

    public void SaveHindernis(GameObject target)
    {
        target.tag = "Hindernis";
        DontDestroyOnLoad(target);
        var test = target.GetComponent<HindernisInputs>();
        Destroy(test);
    }

}
