using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSurfaceTest : ManagerTest
{

    [SerializeField] private bool ShowRay;
    [SerializeField] private float distanceRay;
    [SerializeField] private float offset;
    private Ray ray;

    [SerializeField]
    private MeshFilter mesh;

    [SerializeField]
    private string layer;

    [SerializeField]
    private Transform testContainerTf;

    override protected void Awake()
    {
        base.Awake();
        mesh = this.GetComponent<MeshFilter>();
        GenerateNewTest();
        GenerateNewTest();
        GenerateNewTest();
        GenerateNewTest();
        GenerateNewTest();
        GenerateNewTest();
        GenerateNewTest();
    }
    override public void GenerateNewTest()
    {
        Vector3 directionPoint;
        Vector3 collisionPoint = Vector3.zero;
        //posiblemente esto sea poco optimo
        while (collisionPoint == Vector3.zero )
        {
            directionPoint = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
            collisionPoint = CastRay(directionPoint);
        }


        test = Instantiate(pf_Test, collisionPoint, Quaternion.identity, testContainerTf).GetComponent<Test>();
        test.Manager = this;
        test.e_Complete += CompleteTest;

    }

    private Vector3 CastRay(Vector3 point)
    {
        Vector3 eyesPosition = VRReferences.Instance.HeadsetTf.position;
        ray = new Ray(eyesPosition, (point - eyesPosition));

        if (ShowRay)
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.cyan, 10);
        }

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distanceRay, LayerMask.GetMask(layer, "ObjNoDestruible"), QueryTriggerInteraction.Collide))
        {
            if (hit.transform.gameObject.CompareTag("Vidrio")) {

                return hit.point + (ray.direction.normalized * offset);
            }
        }

        return Vector3.zero;
    }

    private void CompleteTest(GameObject obj)
    {
        Destroy(obj);
        GenerateNewTest();
    }

}
