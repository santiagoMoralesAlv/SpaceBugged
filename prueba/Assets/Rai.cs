using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rai : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position,transform.forward);
        Debug.DrawRay(ray.origin,ray.direction*10,Color.red);

        if (Physics.Raycast(ray,out hit, 10))
        {
            if (hit.collider.CompareTag("Itenm"))
            {
                hit.collider.GetComponent <Renderer> ().material.color = Color.red; 


            }

        }




    }
}
