using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInputs : MonoBehaviour
{
    public InputField breite1;
    public InputField laenge1;
    public InputField abstand1;
    public float obreite, olaenge, oflaeche, oabstand;

    public void SetObjektBreite()
    {
        obreite = float.Parse(breite1.text) / 100;
    }
    public void SetObjektLaenge()
    {
        olaenge = float.Parse(laenge1.text) / 100;
    }
    public void SetObjektAbstand()
    {
        oabstand = float.Parse(abstand1.text) / 100;
    }
    public void SetObjektFlaeche()
    {
        oflaeche = obreite * olaenge;
    }
    public void SavePlayer()
    {
        GlobalControl.Instance.objektbreite = obreite;
        GlobalControl.Instance.objektlaenge = olaenge;
        GlobalControl.Instance.objektabstand = oabstand;
        GlobalControl.Instance.objektflaeche = oflaeche;
    }
}
