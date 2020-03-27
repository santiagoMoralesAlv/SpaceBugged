using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermoFanton : ActiveTool
{
    [SerializeField]
    private float distanceRay;
    private Ray ray;

    private Vector3 pointHit;

    [SerializeField]
    private Transform aim;
    private Transform tf;

    [SerializeField]
    private float energy;

    public Vector3 PointHit { get => pointHit;}
    public Transform Aim { get => aim;}

    new private void Awake()
    {
        base.Awake();
        tf = this.transform;
    }

    override public void Use()
    {
        base.Use();
        ThrowRayCast();
    }

    override public void UnUse()
    {
        base.UnUse();
    }
       
    // Update is called once per frame
    void ThrowRayCast()
    {
        ray = new Ray(tf.position, aim.position- tf.position);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.5f, out hit, distanceRay, LayerMask.GetMask("Esferas"), QueryTriggerInteraction.Collide))
        {
            energy += (0.4f * ((Ship.Instance.SkillControl.LevelPlayer * 0.5f) / 2.5f));
            Destroy(hit.transform.gameObject);
            pointHit = hit.point;
        }
        else {
            pointHit = this.transform.position +( ray.direction* distanceRay);
        }

        //Debug.DrawRay(ray.origin, ray.direction*distanceRay, Color.cyan, 10);
    }

    

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("FuenteEnergia"))
        {
            collider.gameObject.GetComponent<FuenteEnergia>().Heal(energy);
            energy = 0;
        }
    }
}
