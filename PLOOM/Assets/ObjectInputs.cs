using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInputs : MonoBehaviour
{
    public InputField breite1;
    public InputField laenge1;
    public InputField hoehe1;
    public InputField abstand1;
    public InputField sbreite1;
    public InputField slaenge1;
    public InputField shoehe1;


    public float obreite, olaenge, ohoehe, oflaeche, oabstand, sbreite, slaenge, sflaeche, shoehe;

    public void SetObjektBreite()
    {
        obreite = float.Parse(breite1.text) / 100;
    }
    public void SetObjektLaenge()
    {
        olaenge = float.Parse(laenge1.text) / 100;
    }
    public void SetObjektHoehe()
    {
        ohoehe = float.Parse(hoehe1.text) / 100;
    }
    public void SetObjektAbstand()
    {
        oabstand = float.Parse(abstand1.text) / 100;
    }
    public void SetObjektFlaeche()
    {
        oflaeche = ((obreite * 100) * (olaenge * 100)) / 100;
    }

    public void SetStuhlBreite()
    {
        sbreite = float.Parse(sbreite1.text) / 100;
    }

    public void SetStuhlLaenge()
    {
        slaenge = float.Parse(slaenge1.text) / 100;
    }
    public void SetStuhlHoehe()
    {
        shoehe = float.Parse(shoehe1.text) / 100;
    }
    public void SetStuhlFlaeche()
    {
        sflaeche = ((sbreite * 100) * (slaenge * 100)) / 100;
    }
    public void SavePlayer()
    {
        GlobalControl.Instance.objektbreite = obreite;
        GlobalControl.Instance.objektlaenge = olaenge;
        GlobalControl.Instance.objekthoehe = ohoehe;
        GlobalControl.Instance.objektabstand = oabstand;
        GlobalControl.Instance.objektflaeche = oflaeche;
        GlobalControl.Instance.stuhlbreite = sbreite;
        GlobalControl.Instance.stuhllaenge = slaenge;
        GlobalControl.Instance.stuhlhoehe = shoehe;
        GlobalControl.Instance.stuhlflaeche = sflaeche;
    }
}
