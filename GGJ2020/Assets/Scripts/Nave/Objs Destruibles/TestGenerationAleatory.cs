using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGenerationAleatory : MonoBehaviour
{
    [SerializeField]
    private GameObject pf_Test;

    [SerializeField] private bool ShowRay;
    [SerializeField] private float distanceRay;
    private Ray ray;

    [SerializeField]
    private MeshFilter mesh;

    [SerializeField]
    private Transform eyes;

    public GameObject GenerateNewTest(string tagTool) {
        Vector3 newPoint = mesh.mesh.vertices[Random.Range(0, mesh.mesh.vertexCount)];

        GameObject test = null;

        if (CastRay(newPoint, tagTool)) {
            test = Instantiate(pf_Test, newPoint, Quaternion.identity);
        }

        return test;
    }

    private bool CastRay(Vector3 point, string tagTool)
    {

        ray = new Ray(eyes.position, (point - eyes.position));



        if (ShowRay)
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.cyan, 3);
        }

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distanceRay))
        {
            if (hit.transform.CompareTag(tagTool))
            {
                return true;
            }
        }

        return false;

    }

}
