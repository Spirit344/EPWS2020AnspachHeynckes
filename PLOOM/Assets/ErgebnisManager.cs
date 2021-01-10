using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErgebnisManager : MonoBehaviour
{
    public float fbreite, flaenge, fumfang, fflaeche;
    public float obreite, olaenge, oumfang, oabstand, oflaeche, sbreite, slaenge, sflaeche, anzahl;
    public float anzahlx = 0;
    public Text txtanzahl;
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
        oumfang = GlobalControl.Instance.objektumfang;
        oabstand = GlobalControl.Instance.objektabstand;
        oflaeche = GlobalControl.Instance.objektflaeche;
        sbreite = GlobalControl.Instance.stuhlbreite;
        slaenge = GlobalControl.Instance.stuhllaenge;
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
        SetTextAnzahl();
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
    /*public void CubeDraw()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0.6f, 0);
        oscaleChange = new Vector3(obreite, 1, olaenge);
        cube.transform.localScale = oscaleChange;
        Renderer rend = cube.GetComponent<Renderer>();
        rend.material = Resources.Load<Material>("red");
    }*/

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
                cube.transform.position = new Vector3(centerx, 0.6f, centery);
                cube.transform.localScale = new Vector3(obreite, 1, olaenge);
                cube.AddComponent<Rigidbody>();
                cube.AddComponent<Kollision>();
                cube.GetComponent<Renderer>().material = objektmat;

                x = x + abstandx + obreite;
                anzahlx++;
            }
            x = 0;
            y = y + abstandy + olaenge;
        }
        GlobalControl.Instance.objektanzahl = anzahlx;
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
                tisch.transform.position = new Vector3(centerx, 0.6f, (centery + grplaenge / 4));
                tisch.transform.localScale = new Vector3(obreite, 1, olaenge);
                stuhl.transform.position = new Vector3(centerx, 0.3f, (centery - grplaenge / 4));
                stuhl.transform.localScale = new Vector3(sbreite, 0.5f, slaenge);
                stuhl.AddComponent<Rigidbody>();
                stuhl.AddComponent<Kollision>();
                tisch.AddComponent<Rigidbody>();
                tisch.AddComponent<Kollision>();
                stuhl.GetComponent<Renderer>().material = objektmat;
                tisch.GetComponent<Renderer>().material = objektmat;
                stuhl.transform.SetParent(tisch.transform);

                x = x + abstandx + grpbreite;
                anzahlx++;
            }
            x = 0;
            y = y + abstandy + grplaenge;
        }
        GlobalControl.Instance.objektanzahl = anzahlx;
    }
    public void SetTextAnzahl()
    {
        txtanzahl.text = "Objektgruppen: " + GlobalControl.Instance.objektanzahl;
    }

}
