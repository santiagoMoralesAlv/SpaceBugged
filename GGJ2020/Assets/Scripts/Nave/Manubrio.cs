using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manubrio : MonoBehaviour
{
    [SerializeField]
    private bool isRight;
    private MeshRenderer mr;
    private Color initColor;
    AudioSource audioSource;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        initColor = mr.material.color;
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        mr.material.color = new Color(0, 1, 0);
        audioSource.Play();
        if(isRight)
        {
            ShipMov.Instance.Derecha();
        }
        else
        {
            ShipMov.Instance.Izquierda();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        mr.material.color = initColor;
        audioSource.Play();
        ShipMov.Instance.Yano();
    }
}
