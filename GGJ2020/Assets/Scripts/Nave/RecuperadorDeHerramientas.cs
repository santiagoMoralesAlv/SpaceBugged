using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperadorDeHerramientas : MonoBehaviour
{
    [SerializeField]
    private GameObject eje;

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;

        switch (tag) {
            case "Herramienta":
                collision.gameObject.transform.position = eje.transform.position;
                break;
            default:
                break;
        }
    }
}
