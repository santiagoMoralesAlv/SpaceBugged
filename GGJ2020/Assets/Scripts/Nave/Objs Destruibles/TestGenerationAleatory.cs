using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGenerationAleatory : MonoBehaviour
{
    [SerializeField]
    private GameObject pf_Test;

    [SerializeField]
    private Transform[] points;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(GenerateNewTest());
        }
    }

    public GameObject GenerateNewTest() {
        Vector3 verticePoint = Vector3.zero;
        //Vector3 verticePoint = mesh.mesh.vertices[Random.Range(0, mesh.mesh.vertexCount)];

        GameObject test = null;

        test = Instantiate(pf_Test,SelectRandomPoint(),Quaternion.identity);
        VRTK.VRTK_SDKManager.instance.loadedSetup
        return test;
    }
    private Vector3 SelectRandomPoint()
    {
        int num = Random.Range(0,points.Length);
        return points[num].position;
    }

}
