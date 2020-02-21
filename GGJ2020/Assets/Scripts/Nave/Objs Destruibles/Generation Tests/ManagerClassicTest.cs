﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerClassicTest : ManagerTest
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
        Vector3 verticePoint = Vector3.zero;

        int num = Random.Range(0, points.Length);

        GameObject test = null;
        test = Instantiate(pf_Test, points[num].position, Quaternion.identity, points[num]);
        test.GetComponent<Test>().Manager = this;
        test.GetComponent<Test>().e_Complete += CompleteTest;
    }

    private void CompleteTest()
    {
        GenerateNewTest();
    }

}
