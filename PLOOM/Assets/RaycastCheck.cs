using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RaycastCheck : MonoBehaviour
{

    public void Start()
    {
        Invoke("CheckRaycastRichtig", 0.1f);
        //CheckRaycastRichtig();
    }
    public void Update()
    {
        AnzahlObjekte();
    }

    public void CheckRaycastRichtig()
    {
        GameObject[] objektgruppearray = GameObject.FindGameObjectsWithTag("Objekt");
        GameObject[] sprecherarray = GameObject.FindGameObjectsWithTag("Sprecher");

        foreach (GameObject objektgruppe in objektgruppearray)
        {
            bool seespeaker = false;

            foreach (GameObject sprecher in sprecherarray)
            {
                RaycastHit hit;

                if (Physics.Linecast(sprecher.transform.position, objektgruppe.transform.position, out hit))
                {
                    Debug.DrawLine(sprecher.transform.position, objektgruppe.transform.position, Color.blue, 1000);
                    //Debug.Log("hit: " + hit.collider.name);

                    if (hit.collider.tag != "Hindernis")
                    {
                        seespeaker = true;
                    }
                }

            }
            if (!seespeaker)
            {
                if (objektgruppe.transform.parent != null)
                {
                    Destroy(objektgruppe.transform.parent.gameObject);
                }
                else
                {
                    Destroy(objektgruppe);
                }
            }

        }
    }

    public void AnzahlObjekte()
    {
        int arrayanzahl = 0;
        GameObject[] objektgruppearray = GameObject.FindGameObjectsWithTag("Objekt");
        foreach (GameObject objekt in objektgruppearray)
        {
            if (objekt.name == "Tisch")
            {
                arrayanzahl++;
            }
        }
        GlobalControl.Instance.objektanzahl = arrayanzahl;

    }

    /*public void CheckRaycast()
    {
        GameObject[] sprecherarray = GameObject.FindGameObjectsWithTag("Sprecher");
        RaycastHit hit;
        foreach (GameObject sprecher in sprecherarray)
        {
            if (Physics.Linecast(sprecher.transform.position, gameObject.transform.position, out hit))
            {
                if (gameObject.transform.parent != null)
                {
                    Destroy(gameObject.transform.parent.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }*/

    /*
    public void CheckRaycastHit()
    {
        GameObject[] sprecherarray;
        List<GameObject> deleteobjekt = new List<GameObject>();
        GameObject[] objektgruppearray;

        objektgruppearray = GameObject.FindGameObjectsWithTag("Objekt");
        Debug.Log("Objekte: " + objektgruppearray.Length);

        sprecherarray = GameObject.FindGameObjectsWithTag("Sprecher");
        Debug.Log("Sprecher: " + sprecherarray.Length);
        foreach (GameObject objektgruppe in objektgruppearray)
        {
            foreach (GameObject sprecher in sprecherarray)
            {
                RaycastHit hit;
                //Physics.Linecast(sprecher.transform.position, objektgruppe.transform.position, out hit);

                if (Physics.Linecast(sprecher.transform.position, objektgruppe.transform.position, out hit))
                {
                    Debug.DrawLine(sprecher.transform.position, objektgruppe.transform.position, Color.blue, 1000);
                    Debug.Log("hit: " + hit.collider.name);

                    if (hit.collider.tag == "Hindernis")
                    {
                        deleteobjekt.Add(objektgruppe);

                        /*if (gameObject.transform.parent != null)
                        {
                            deleteobjekt.Add(gameObject);
                            //Destroy(gameObject.transform.parent.gameObject);
                        }
                        else
                        {
                            deleteobjekt.Add(gameObject);
                            //Destroy(gameObject);
                        }
                    }
                }
            }
        }
        Debug.Log("Liste " + deleteobjekt.ToArray().Length);
        foreach (GameObject deleteo in deleteobjekt.ToArray())
        {
            Destroy(deleteo);
        }
    }
*/

}
