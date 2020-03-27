using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : ActiveTool
{

    [SerializeField]
    private float distanceRay, radius;

    [SerializeField]
    private Transform aim, pointA, pointB;
    private Transform tf;

    new private void Awake()
    {
        base.Awake();
        tf = this.transform;
    }

    private void Update()
    {
        if (inUse) {
            //ThrowRayCast();
        }
    }


    // Update is called once per frame
    void ThrowRayCast()
    {
        RaycastHit hit;

        if (Physics.CapsuleCast(pointA.position, pointB.position, radius, aim.position - tf.position, out hit, distanceRay, LayerMask.GetMask("Test"), QueryTriggerInteraction.Collide))
        {
            if (hit.collider.CompareTag("GlassTest")) {
                hit.collider.GetComponent<Test>().Show(true);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (inUse)
        {
            if (collider.CompareTag("GlassTest"))
            {
                collider.GetComponent<Test>().Show(true);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("GlassTest"))
        {
            collider.GetComponent<Test>().Show(false);
        }
    }

}
