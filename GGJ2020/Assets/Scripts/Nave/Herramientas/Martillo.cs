using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martillo : ActiveTool
{
    [SerializeField]
    private float capacityToRepair, capacityToRepairWithTest;

    override public void Use()
    {
        inUse = true;
        Notify();
    }

    override public void UnUse()
    {
        inUse = false;
        Notify();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Motor"))
        {
            if (inUse)
            {
                collision.gameObject.GetComponent<Motor>().Heal(capacityToRepair);
            }
        }

        if (collision.gameObject.CompareTag("Test"))
        {
            if (inUse)
            {
                Test t_test = collision.gameObject.GetComponent<Test>();
                if (t_test.Manager.PartDestruible is Motor)
                {
                    t_test.Manager.PartDestruible.Heal(capacityToRepairWithTest);
                    t_test.OnCompleteTest();
                }
            }
        }

    }
}
