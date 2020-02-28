using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperadorDeHerramientas : MonoBehaviour
{
    [SerializeField]
    private GameObject eje;
    
    private void OnTriggerExit(Collider other)
    {
        string tag = other.gameObject.tag;

        switch (tag)
        {
            case "Herramienta":
                other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.gameObject.transform.position = eje.transform.position;
                break;
            default:
                break;
        }
    }
}
