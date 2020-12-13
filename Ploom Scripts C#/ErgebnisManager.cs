using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErgebnisManager : MonoBehaviour
{
    public float fbreite, flaenge, fumfang, fflaeche;
    public float obreite, olaenge, oumfang, oabstand, oflaeche;
    private GameObject floor;
    private Vector3 scaleChange;
    private GameObject cube;
    private Vector3 oscaleChange;
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
        //SetFloorFlaeche();
        FloorDraw();
        //SetObjektFlaeche();
        ObjektDraw();
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
                cube.transform.position = new Vector3(centerx, 0.6f, centery);
                cube.transform.localScale = new Vector3(obreite, 1, olaenge);
                x = x + abstandx + obreite;
            }
            x = 0;
            y = y + abstandy + olaenge;
        }
    }
}
