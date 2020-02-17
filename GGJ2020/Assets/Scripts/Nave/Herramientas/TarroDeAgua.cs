using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarroDeAgua : ActiveTool
{

    [SerializeField]
    private float distanceRay, distanceObj;
    private Ray ray;


    // Update is called once per frame
    void ThrowRayCast()
    {
        //se tiene q reemplazar por la direccion del control del oculus
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanceRay, LayerMask.GetMask("Vidrio"), QueryTriggerInteraction.Collide))
        {
            Ship.Instance.ApplyGlassHeal(0.1f);
        }


    }
    override protected void Use()
    {
        Notify();
    }

}
