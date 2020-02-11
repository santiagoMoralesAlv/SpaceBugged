using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduccion : MonoBehaviour
{
    public GameObject sc1,sc2,sc2_1;
    public ControlGame cg;
    private float lastTime;
    private int state;
    private float intervalo;
    public AudioSource audiosource;
    public AudioClip introloop, playloop;

    void Start()
    {
        intervalo = 10;
        state = 0;
        lastTime = Time.time;
    }
    
    void Update()
    {
        switch(state)
        {
            case 0:
                if (Time.time - lastTime > intervalo)
                {
                    state = 1;
                    sc1.SetActive(false);
                    sc2.SetActive(true);
                    lastTime = Time.time;
                }
                break;
            case 1:
                if (Time.time - lastTime > intervalo)
                {
                    state = 2;
                    sc2.SetActive(false);
                    sc1.SetActive(true);
                    sc2_1.SetActive(false);
                    lastTime = Time.time;
                    cg.StartGame();
                    audiosource.Stop();
                    audiosource.clip = playloop;
                    audiosource.Play();
                }
                break;
            case 2:
                break;
        }
    }
}