using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMeteoros : MonoBehaviour
{
    public GameObject[] meteoros;
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
            intervalo = Random.Range((ControlGame.Instance.Difficulty) - 2, (ControlGame.Instance.Difficulty) + 2);
        }
    }

    void Generar()
    {
        int i = (int)Mathf.Floor(Random.Range(0,1.9f));

        Vector3 pos = new Vector3(30, Random.Range(1f, 2f), Ship.Instance.gameObject.transform.localPosition.z + Random.Range(-10, 10));

        Instantiate(meteoros[i], pos, Quaternion.identity, gameObject.transform);
    }
}