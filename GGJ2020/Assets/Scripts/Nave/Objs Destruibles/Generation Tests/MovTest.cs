using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovTest : Test
{
    public UnityAction e_RequestNewPoint;

    private Transform pointToMov, tf;

    [SerializeField]
    private float distanceMinToChangePoint, velocity;


    private void Awake()
    {
        tf = this.transform;
    }

    void Update()
    {
        Mov();
    }

    public void Mov()
    {
        if(Vector3.Distance(tf.position, pointToMov.position)< distanceMinToChangePoint)
        {
            if(e_RequestNewPoint != null)
            {
                e_RequestNewPoint();
            }
        }
        else
        {
            tf.position = Vector3.Lerp(tf.position, pointToMov.position, velocity*Time.deltaTime);
        }
    }

    public void ChangePoint(Transform newPoint)
    {
        pointToMov = newPoint;
    }
}
