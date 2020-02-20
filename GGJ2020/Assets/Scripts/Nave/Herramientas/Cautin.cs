using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cautin : ActiveTool
{
    private int numCableToRepair;
    [SerializeField]
    private float capacityToRepair;

    override public void Use() {
        inUse =true;
        Notify();
    }

    override public void UnUse()
    {
        inUse = false;
        Notify();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Cables"))
        {
            numCableToRepair = collider.gameObject.GetComponent<Cable>().NumCable;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Cables"))
        {
            if (inUse)
            {

                Ship.Instance.ApplyCableHeal(numCableToRepair, capacityToRepair * Time.deltaTime);
            }
        }

    }
}
