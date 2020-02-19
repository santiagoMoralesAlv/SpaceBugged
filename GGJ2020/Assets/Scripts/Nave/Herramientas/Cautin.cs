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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cables"))
        {
            numCableToRepair = collision.gameObject.GetComponent<Cable>().NumCable;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cables")) {
            if (inUse)
            {

                Ship.Instance.ApplyCableHeal(numCableToRepair, capacityToRepair * Time.deltaTime);
            }
        }
    }
}
