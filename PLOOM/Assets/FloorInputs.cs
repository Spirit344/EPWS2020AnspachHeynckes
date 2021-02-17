using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FloorInputs : MonoBehaviour
{
    public InputField breite;
    public InputField laenge;
    public Text reminder;
    public float fbreite, flaenge, fflaeche;

    public void SetFloorBreite()
    {
        fbreite = float.Parse(breite.text);
    }
    public void SetFloorLaenge()
    {
        flaenge = float.Parse(laenge.text);
    }
    public void SetFloorFlaeche()
    {
        if (breite.text == "" || laenge.text == "")
        {
            reminder.gameObject.SetActive(true);
        }
        else
        {
            fflaeche = fbreite * flaenge;
            string menue = "Scene3Objekt";
            ButtonMoveScene(menue);
            reminder.gameObject.SetActive(false);
        }
    }
    public void ButtonMoveScene(string menue)
    {
        SceneManager.LoadScene(menue);
    }
    public void SavePlayer()
    {
        GlobalControl.Instance.raumbreite = fbreite;
        GlobalControl.Instance.raumlaenge = flaenge;
        GlobalControl.Instance.raumflaeche = fflaeche;
    }
}
