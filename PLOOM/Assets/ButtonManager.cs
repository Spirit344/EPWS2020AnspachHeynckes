using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private GameObject hindernis, sprecher;
    private Vector3 scaleChange;
    private float fbreite, flaenge;
    public GameObject[] hindernisse;
    public GameObject target;
    public Material hindernismat, sprechermat;
    public InputField hheight, sheight;
    public float heighth, heights;

    public void ButtonMoveScene(string menue)
    {
        SceneManager.LoadScene(menue);
    }
    public void AddHindernis()
    {
        fbreite = GlobalControl.Instance.raumbreite;
        flaenge = GlobalControl.Instance.raumlaenge;

        hindernis = GameObject.CreatePrimitive(PrimitiveType.Cube);
        if (hheight.text != "")
        {
            heighth = float.Parse(hheight.text) / 100;
            hindernis.transform.position = new Vector3((-fbreite / 2), ((heighth / 2) + 0.11f), (flaenge / 2));
            scaleChange = new Vector3(2, heighth, 2);
            hindernis.transform.localScale = scaleChange;
        }
        else
        {
            hindernis.transform.position = new Vector3((-fbreite / 2), 0.11f, (flaenge / 2));
            scaleChange = new Vector3(2, 0.11f, 2);
        }
        hindernis.transform.localScale = scaleChange;
        hindernis.GetComponent<BoxCollider>().enabled = true;
        hindernis.AddComponent<HindernisInputs>();
        hindernis.GetComponent<Renderer>().material = hindernismat;
        hindernis.name = "Hindernis";
        hindernis.tag = "Hindernis";
    }
    public void AddSprecher()
    {
        fbreite = GlobalControl.Instance.raumbreite;
        flaenge = GlobalControl.Instance.raumlaenge;

        sprecher = GameObject.CreatePrimitive(PrimitiveType.Cube);
        if (sheight.text != "")
        {
            heights = float.Parse(sheight.text) / 100;
            sprecher.transform.position = new Vector3((-fbreite / 2), ((heights / 2) + 0.11f), (flaenge / 2));
            scaleChange = new Vector3(1.5f, heights, 1.5f);
            sprecher.transform.localScale = scaleChange;
        }
        else
        {
            sprecher.transform.position = new Vector3((-fbreite / 2), 0.11f, (flaenge / 2));
            scaleChange = new Vector3(1.5f, 0.11f, 1.5f);
        }
        sprecher.GetComponent<BoxCollider>().enabled = true;
        sprecher.AddComponent<HindernisInputs>();
        sprecher.GetComponent<Renderer>().material = sprechermat;
        sprecher.name = "SprecherObjekt";
        sprecher.tag = "Sprecher";
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void HindernisEntfernen()
    {
        target = GlobalControl.Instance.target;
        Destroy(target);
    }
    public void NeuBerechnen()
    {

        var go = new GameObject("Sacrificial Lamb");
        DontDestroyOnLoad(go);

        foreach (var root in go.scene.GetRootGameObjects())
            Destroy(root);

    }
}
