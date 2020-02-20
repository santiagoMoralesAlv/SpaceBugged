using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGenerationAleatory : MonoBehaviour
{
    [SerializeField]
    private GameObject pf_Test;

    [SerializeField]
    private Transform[] points;
    
    public void GenerateNewTest() {
        Vector3 verticePoint = Vector3.zero;

        GameObject test = null;

        int num = Random.Range(0, points.Length);

        test = Instantiate(pf_Test, points[num].position, Quaternion.identity, points[num]);
        test.GetComponent<Test>().e_Complete += GenerateNewTest;
        test.GetComponent<Test>().SuscribeTest();
        //VRTK.VRTK_SDKManager.instance.loadedSetup.actualHeadset.transform;
    }

}
