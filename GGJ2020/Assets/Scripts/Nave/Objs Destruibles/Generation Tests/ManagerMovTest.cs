using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMovTest : ManagerTest
{

    [SerializeField]
    private Transform[] points;


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

        (test as MovTest).e_RequestNewPoint += ChangePoint;
    }

    private void ChangePoint()
    {
        int num = Random.Range(0, points.Length);
        (test as MovTest).ChangePoint(points[num]);
    }
}
