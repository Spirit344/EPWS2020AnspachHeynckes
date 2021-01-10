using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public float raumbreite, raumlaenge, raumumfang, raumflaeche, objektbreite, objektlaenge, objektumfang, objektabstand, objektflaeche, stuhlbreite, stuhllaenge, stuhlflaeche, objektanzahl;
    public static GlobalControl Instance;

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