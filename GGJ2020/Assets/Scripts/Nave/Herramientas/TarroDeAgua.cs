﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarroDeAgua : ActiveTool
{

    [SerializeField]
    private float distanceRay;
    private Ray ray;

    [SerializeField]
    private Transform eje, aim;
    private Transform tf;

    [SerializeField]
    private float energy, radius, capacityToCharge;

    private void Awake()
    {
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

    private void Update()
    {
        capacityToCharge += Time.deltaTime;
    }

    void ThrowRayCast()
    {
        ray = new Ray(tf.position, aim.position - tf.position);
        RaycastHit hit;

        if (Physics.SphereCast(eje.position, radius, eje.position+aim.localPosition, out hit, distanceRay, LayerMask.GetMask("Test"), QueryTriggerInteraction.Collide))
        {
            if (hit.collider.gameObject.CompareTag("GlassTest"))
            {
                Test t_test = hit.collider.gameObject.GetComponent<Test>();
                if (t_test.Manager.PartDestruible is Vidrio)
                {
                    float i = Mathf.Clamp(energy, 0, 0.2f);
                    t_test.Manager.PartDestruible.Heal(i);
                    energy -= i;
                    t_test.OnCompleteTest();                    
                }
                
            }
                
        }

        Debug.DrawRay(eje.position, eje.position + aim.localPosition * distanceRay, Color.cyan, 10);
    }
}
