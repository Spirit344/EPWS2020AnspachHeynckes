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
        var cubeRenderer = hindernis.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.red);
    }
}
