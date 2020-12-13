using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorInputs : MonoBehaviour
{
    public InputField breite;
    public InputField laenge;
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
        fflaeche = fbreite * flaenge;
    }
    public void SavePlayer()
    {
        GlobalControl.Instance.raumbreite = fbreite;
        GlobalControl.Instance.raumlaenge = flaenge;
        GlobalControl.Instance.raumflaeche = fflaeche;
    }
}
