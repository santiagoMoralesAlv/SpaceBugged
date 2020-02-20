using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSurfaceTest : ManagerTest
{

    [SerializeField] private bool ShowRay;
    [SerializeField] private float distanceRay;
    private Ray ray;

    [SerializeField]
    private MeshFilter mesh;

    [SerializeField]
    private string layer;

    private Transform tf;

    private void Awake()
    {
        tf = this.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GenerateNewTest();
        }
    }

    override public void GenerateNewTest()
    {
        Vector3 verticePoint = mesh.mesh.vertices[Random.Range(0, mesh.mesh.vertexCount)];
        Vector3 collisionPoint = Vector3.zero;

        while (collisionPoint == Vector3.zero)
        {
            collisionPoint = CastRay(verticePoint);
        }

        GameObject test = null;
        test = Instantiate(pf_Test, collisionPoint, Quaternion.identity, tf);
        test.GetComponent<Test>().e_Complete += CompleteTest;

    }

    private Vector3 CastRay(Vector3 point)
    {
        Vector3 eyesPosition = VRTK.VRTK_SDKManager.instance.loadedSetup.actualHeadset.transform.position;
        ray = new Ray(eyesPosition, (point - eyesPosition));

        if (ShowRay)
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.cyan, 3);
        }

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distanceRay, LayerMask.GetMask(layer), QueryTriggerInteraction.Collide))
        {
            return hit.point+(-ray.direction.normalized);
        }

        return Vector3.zero;
    }

    private void CompleteTest()
    {
        GenerateNewTest();
    }

}
