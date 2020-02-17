using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoMeteoro : MonoBehaviour
{
    float interval, lastTime;

    void Start()
    {
        interval = 5;
        lastTime = Time.time;
    }
    
    void Update()
    {
        if (Time.time - lastTime > interval)
        {
            Destroy(gameObject);
        }
    }
}