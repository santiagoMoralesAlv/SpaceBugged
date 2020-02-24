using System.Collections;
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

        test = Instantiate(pf_Test, points[num].position, Quaternion.identity, points[num]).GetComponent<Test>();
        test.Manager = this;
        test.e_Complete += CompleteTest;
    }

    private void CompleteTest(GameObject obj)
    {
        Destroy(obj);
        GenerateNewTest();
    }

}
