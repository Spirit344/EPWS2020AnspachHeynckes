using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private GameObject hindernis;
    private Vector3 scaleChange;
    private float fbreite, flaenge;
    public GameObject[] hindernisse;

    public Material hindernismat;
    public void ButtonMoveScene(string menue)
    {
        SceneManager.LoadScene(menue);
    }
    public void AddHindernis()
    {
        fbreite = GlobalControl.Instance.raumbreite;
        flaenge = GlobalControl.Instance.raumlaenge;

        hindernis = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hindernis.transform.position = new Vector3((-fbreite / 2), 0.11f, (flaenge / 2));
        scaleChange = new Vector3(2, 0.02f, 2);
        hindernis.transform.localScale = scaleChange;
        hindernis.GetComponent<BoxCollider>().enabled = true;
        hindernis.AddComponent<HindernisInputs>();
        hindernis.GetComponent<Renderer>().material = hindernismat;
    }

    public void DeleteHindernis()
    {
        if (hindernis != null)
        {
            Destroy(hindernis);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    /*public void NeuBerechnen()
    {
        hindernisse = GameObject.FindGameObjectsWithTag("Hindernis");

        foreach (GameObject hindernis in hindernisse)
        {
            Destroy(gameObject);
        }
    }*/
    public void NeuBerechnen()
    {

        var go = new GameObject("Sacrificial Lamb");
        DontDestroyOnLoad(go);

        foreach (var root in go.scene.GetRootGameObjects())
            Destroy(root);

    }
}
