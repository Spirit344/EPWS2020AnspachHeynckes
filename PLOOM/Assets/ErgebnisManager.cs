using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErgebnisManager : MonoBehaviour
{
    public float fbreite, flaenge, fumfang, fflaeche;
    public float obreite, olaenge, ohoehe, oumfang, oabstand, oflaeche, sbreite, slaenge, shoehe, sflaeche, anzahl;
    public int anzahlx = 0;
    public Text txtanzahl, txtabstand, txtrbreite, txtrlaenge, txtrflaeche, txtobreite, txtolaenge, txtohoehe, txtoflaeche;
    private GameObject floor;
    private Vector3 scaleChange;
    private GameObject cube, tisch, stuhl;
    private Vector3 oscaleChange;
    public Material floormat, objektmat;

    void Start()
    {
        fbreite = GlobalControl.Instance.raumbreite;
        flaenge = GlobalControl.Instance.raumlaenge;
        fumfang = GlobalControl.Instance.raumumfang;
        fflaeche = GlobalControl.Instance.raumflaeche;
        obreite = GlobalControl.Instance.objektbreite;
        olaenge = GlobalControl.Instance.objektlaenge;
        ohoehe = GlobalControl.Instance.objekthoehe;
        oumfang = GlobalControl.Instance.objektumfang;
        oabstand = GlobalControl.Instance.objektabstand;
        oflaeche = GlobalControl.Instance.objektflaeche;
        sbreite = GlobalControl.Instance.stuhlbreite;
        slaenge = GlobalControl.Instance.stuhllaenge;
        shoehe = GlobalControl.Instance.stuhlhoehe;
        sflaeche = GlobalControl.Instance.stuhlflaeche;

        FloorDraw();
        if (sflaeche != 0)
        {
            ObjektGroupDraw();
        }
        else
        {
            ObjektDraw();
        }

    }
    void Update()
    {
        SetTextBoxen();
    }
    public float SetFloorFlaeche()
    {
        fflaeche = fbreite * flaenge;
        return fflaeche;
    }
    public void FloorDraw()
    {
        floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.transform.position = new Vector3((fbreite / 2), 0, (flaenge / 2));
        scaleChange = new Vector3(fbreite, 0.2f, flaenge);
        floor.transform.localScale = scaleChange;
        floor.GetComponent<Renderer>().material = floormat;
    }
    public float SetObjektFlaeche()
    {
        oflaeche = obreite * olaenge;
        return oflaeche;
    }

    public float AbstandBerechnen(float raumlb, float objektlb, float mindestabstand)
    {
        int anzahl = (int)(raumlb / (objektlb + mindestabstand));
        float rest = raumlb % (objektlb + mindestabstand);
        float abstand = (anzahl * mindestabstand + rest) / (anzahl + 1);
        return abstand;
    }

    public void ObjektDraw()
    {
        float x = 0;
        float y = 0;
        float abstandx = AbstandBerechnen(fbreite, obreite, oabstand);
        float abstandy = AbstandBerechnen(flaenge, olaenge, oabstand);

        while (y + abstandy + olaenge <= flaenge)
        {
            float centery = y + abstandy + (olaenge / 2);

            while (x + abstandx + obreite <= fbreite)
            {
                float centerx = x + abstandx + (obreite / 2);
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.tag = "Objekt";
                cube.transform.position = new Vector3(centerx, (ohoehe / 2 + 0.1f), centery);
                cube.transform.localScale = new Vector3(obreite, ohoehe, olaenge);
                cube.AddComponent<Rigidbody>();
                cube.AddComponent<Kollision>();
                //cube.AddComponent<RaycastCheck>();
                cube.GetComponent<Renderer>().material = objektmat;
                cube.name = "Tisch";

                x = x + abstandx + obreite;
                anzahlx++;
            }
            x = 0;
            y = y + abstandy + olaenge;
        }
    }

    public float GrpBreite(float objektb, float stuhlb)
    {
        float grpbreite;

        if (objektb < stuhlb)
        {
            grpbreite = stuhlb;
            return grpbreite;
        }
        else
        {
            grpbreite = objektb;
            return grpbreite;
        }
    }
    public float GrpLaenge(float objektl, float stuhll)
    {
        float grplaenge;
        grplaenge = objektl + 0.3f + stuhll + 0.3f;
        return grplaenge;
    }

    public void ObjektGroupDraw()
    {
        float x = 0;
        float y = 0;
        float grpbreite = GrpBreite(obreite, sbreite);
        float grplaenge = GrpLaenge(olaenge, slaenge);

        float abstandx = AbstandBerechnen(fbreite, grpbreite, oabstand);
        float abstandy = AbstandBerechnen(flaenge, grplaenge, oabstand);

        while (y + abstandy + grplaenge <= flaenge)
        {
            float centery = y + abstandy + (grplaenge / 2);

            while (x + abstandx + grpbreite <= fbreite)
            {
                float centerx = x + abstandx + (grpbreite / 2);
                tisch = GameObject.CreatePrimitive(PrimitiveType.Cube);
                stuhl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                tisch.tag = "Objekt";
                stuhl.tag = "Objekt";
                tisch.transform.position = new Vector3(centerx, ((ohoehe / 2) + 0.1f), (centery + grplaenge / 4));
                tisch.transform.localScale = new Vector3(obreite, ohoehe, olaenge);
                stuhl.transform.position = new Vector3(centerx, ((shoehe / 2) + 0.1f), (centery - grplaenge / 4));
                stuhl.transform.localScale = new Vector3(sbreite, shoehe, slaenge);
                stuhl.AddComponent<Rigidbody>();
                stuhl.AddComponent<Kollision>();
                tisch.AddComponent<Rigidbody>();
                tisch.AddComponent<Kollision>();
                stuhl.GetComponent<Renderer>().material = objektmat;
                tisch.GetComponent<Renderer>().material = objektmat;
                tisch.name = "Tisch";
                stuhl.name = "Stuhl";
                stuhl.transform.SetParent(tisch.transform);

                x = x + abstandx + grpbreite;
                anzahlx++;
            }
            x = 0;
            y = y + abstandy + grplaenge;
        }
    }
    public void SetTextBoxen()
    {
        txtanzahl.text = "Objektgruppen: " + GlobalControl.Instance.objektanzahl;
        txtabstand.text = "Optimaler Abstand zw.\nObjektgruppen(m): " + AbstandBerechnen(fbreite, GrpBreite(obreite, sbreite), oabstand).ToString("F2");
        txtrbreite.text = "Raumbreite(m): " + GlobalControl.Instance.raumbreite.ToString("F2");
        txtrlaenge.text = "Raumlänge(m): " + GlobalControl.Instance.raumlaenge.ToString("F2");
        txtrflaeche.text = "Raumfläche(m^2): " + GlobalControl.Instance.raumflaeche;
        txtobreite.text = "Objektbreite(m): " + GlobalControl.Instance.objektbreite.ToString("F2");
        txtolaenge.text = "Objektlaenge(m): " + GlobalControl.Instance.objektlaenge.ToString("F2");
        txtohoehe.text = "Objekthoehe(m): " + GlobalControl.Instance.objekthoehe.ToString("F2");
        txtoflaeche.text = "Objektfläche(m): " + (GlobalControl.Instance.objektflaeche / 100).ToString("F2");
    }
}
