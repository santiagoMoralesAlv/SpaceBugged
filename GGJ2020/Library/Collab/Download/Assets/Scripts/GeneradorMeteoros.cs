using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMeteoros : MonoBehaviour
{
    public Transform nave;
    public GameObject meteoro;
    public float intensidad;
    private float intervalo;
    private float lastTime;

    void Start()
    {
        intervalo = Random.Range(intensidad - 2, intensidad + 2);
        lastTime = Time.time;
    }

    void Update()
    {
        if(Time.time - lastTime > intervalo)
        {
            Generar();
            lastTime = Time.time;
            intervalo = Random.Range(intensidad - 2, intensidad + 2);
        }
    }

    void Generar()
    {
        Vector3 pos = new Vector3(30, Random.Range(1f, 8f), nave.localPosition.z + Random.Range(-10, 10));
        Instantiate(meteoro, pos, Quaternion.identity, gameObject.transform);
    }
}