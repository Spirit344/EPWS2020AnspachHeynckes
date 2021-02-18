using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Text reminder;


    public float obreite, olaenge, ohoehe, oflaeche, oabstand, sbreite, slaenge, sflaeche, shoehe;

    public void SetObjektBreite()
    {
        obreite = float.Parse(breite1.text) / 100;
        GlobalControl.Instance.objektbreite = obreite;
    }
    public void SetObjektLaenge()
    {
        olaenge = float.Parse(laenge1.text) / 100;
        GlobalControl.Instance.objektlaenge = olaenge;
    }
    public void SetObjektHoehe()
    {
        ohoehe = float.Parse(hoehe1.text) / 100;
        GlobalControl.Instance.objekthoehe = ohoehe;
    }
    public void SetObjektAbstand()
    {
        oabstand = float.Parse(abstand1.text) / 100;
        GlobalControl.Instance.objektabstand = oabstand;
    }
    public void SetObjektFlaeche()
    {
        oflaeche = ((obreite * 100) * (olaenge * 100)) / 100;
        GlobalControl.Instance.objektflaeche = oflaeche;
    }

    public void SetStuhlBreite()
    {
        sbreite = float.Parse(sbreite1.text) / 100;
        GlobalControl.Instance.stuhlbreite = sbreite;
    }

    public void SetStuhlLaenge()
    {
        slaenge = float.Parse(slaenge1.text) / 100;
        GlobalControl.Instance.stuhllaenge = slaenge;
    }
    public void SetStuhlHoehe()
    {
        shoehe = float.Parse(shoehe1.text) / 100;
        GlobalControl.Instance.stuhlhoehe = shoehe;
    }
    public void SetStuhlFlaeche()
    {
        sflaeche = ((sbreite * 100) * (slaenge * 100)) / 100;
        GlobalControl.Instance.stuhlflaeche = sflaeche;
    }
    public void Next()
    {
        if (abstand1.text == "" || breite1.text == "" || laenge1.text == "" || hoehe1.text == "")
        {
            reminder.gameObject.SetActive(true);
        }
        else
        {
            SetObjektBreite();
            SetObjektLaenge();
            SetObjektHoehe();
            SetObjektFlaeche();
            if (sbreite1.text != "" && slaenge1.text != "" && shoehe1.text != "")
            {
                SetStuhlBreite();
                SetStuhlLaenge();
                SetStuhlFlaeche();
                SetStuhlHoehe();
            }
            SetObjektAbstand();
            reminder.gameObject.SetActive(false);
            string menue = "Scene3.5Hindernis";
            SceneManager.LoadScene(menue);
        }
    }
}
