using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMovTest : ManagerTest
{

    [SerializeField]
    private Transform[] points;
    private MovTest test;


    override protected void Awake()
    {
        base.Awake();
        GenerateNewTest();
    }

    override public void GenerateNewTest()
    {
        int num = Random.Range(0, points.Length);

        test = Instantiate(pf_Test, points[num].position, Quaternion.identity, points[num]).GetComponent<MovTest>();
        test.Manager = this;
        ChangePoint();

        test.e_RequestNewPoint += ChangePoint;
    }

    private void ChangePoint()
    {
        int num = Random.Range(0, points.Length);
        test.ChangePoint(points[num]);
    }
}
