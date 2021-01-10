using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kollision : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hindernis"))
        {
            if (gameObject.transform.parent != null)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
            Destroy(gameObject);
            GlobalControl.Instance.objektanzahl = GlobalControl.Instance.objektanzahl - 1;
        }

    }
}
