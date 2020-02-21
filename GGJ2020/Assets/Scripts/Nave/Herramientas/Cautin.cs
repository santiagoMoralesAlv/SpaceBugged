using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cautin : ActiveTool
{
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


    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Cables"))
        {
            if (inUse)
            {
                collider.gameObject.GetComponent<Cable>().Heal(capacityToRepair);
            }
        }

        if (collider.gameObject.CompareTag("Test"))
        {
            if (inUse)
            {
                Test t_test = collider.gameObject.GetComponent<Test>();
                if (t_test.Manager.PartDestruible is Cable)
                {
                    t_test.Manager.PartDestruible.Heal(capacityToRepairWithTest);
                    t_test.OnCompleteTest();
                }
            }
        }

    }
}
