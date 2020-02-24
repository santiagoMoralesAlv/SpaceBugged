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

    private void Awake()
    {
        tf = this.transform;
    }

    private void Update()
    {
        if (inUse) {
            ThrowRayCast();
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

}
