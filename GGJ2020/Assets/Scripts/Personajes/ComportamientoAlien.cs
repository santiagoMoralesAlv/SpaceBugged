using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoAlien : MonoBehaviour
{
    AudioSource audioSource;
    float interval, lastTime;
    public AudioClip vomito, correr, risa, cuidado, mareo;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastTime = Time.time;
        interval = 20;
    }
    
    void Update()
    {
        if(Time.time - lastTime > interval)
        {
            int r = Random.Range(0, 10);
            if(r < 2)
            {
                audioSource.clip = risa;
            }
            else if(r < 4)
            {
                audioSource.clip = vomito;
            }
            else if (r < 6)
            {
                audioSource.clip = cuidado;
            }
            else if (r < 8)
            {
                audioSource.clip = mareo;
            }
            else
            {
                audioSource.clip = correr;
            }


            audioSource.Play();
        }
    }
}
