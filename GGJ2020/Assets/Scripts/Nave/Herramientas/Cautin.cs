using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cautin : ActiveTool
{
    private int numCableToRepair;
    [SerializeField]
    private float capacityToRepair, capacityToRepairWithTest;

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

        if (collider.gameObject.CompareTag("Test"))
        {
            Test t_test =  collider.gameObject.GetComponent<Test>();
            t_test.Manager.PartDestruible.Heal(capacityToRepairWithTest);
            t_test.OnCompleteTest();
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Cables"))
        {
            if (inUse)
            {
                collider.gameObject.GetComponent<Cable>().Heal(capacityToRepair);
            }
        }

    }
}
