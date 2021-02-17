using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public float raumbreite, raumlaenge, raumumfang, raumflaeche, objektbreite, objektlaenge, objekthoehe, objektumfang, objektabstand, objektflaeche, stuhlbreite, stuhllaenge, stuhlhoehe, stuhlflaeche;
    public int objektanzahl;
    public static GlobalControl Instance;
    public GameObject target;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}