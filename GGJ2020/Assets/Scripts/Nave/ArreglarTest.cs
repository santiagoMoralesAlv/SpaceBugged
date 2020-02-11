using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArreglarTest : MonoBehaviour
{
    bool damaged;
    public GameObject cautin;
    ParticleSystem cautinPar;
    MeshRenderer myMesh;

    private void Awake()
    {
        cautinPar = cautin.GetComponent<ParticleSystem>();
        myMesh = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        damaged = true;
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "martillo")
        {
            if (damaged)
            {
                myMesh.material.color = new Color(0, 1, 0);
                damaged = false;
            }
            else
            {
                myMesh.material.color = new Color(1, 0, 0);
                damaged = true;
            }
        }
        if (other.gameObject.tag == "cautin")
        {
            myMesh.material.color = new Color(0, 1, 0);
            cautinPar.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cautin")
        {
            myMesh.material.color = new Color(1, 0, 0);
            cautinPar.Stop();
        }
    }
}
