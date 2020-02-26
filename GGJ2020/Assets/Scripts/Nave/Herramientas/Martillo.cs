using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martillo : ActiveTool
{
    [SerializeField]
    private float capacityToRepair, capacityToRepairWithTest;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Motor"))
        {
            if (inUse)
            {
                collision.gameObject.GetComponent<Motor>().Heal(capacityToRepair* ((Ship.Instance.SkillControl.LevelPlayer * 0.5f) / 2.5f));
            }
        }

        if (collision.gameObject.CompareTag("Test"))
        {
            if (inUse)
            {
                Test t_test = collision.gameObject.GetComponent<Test>();
                if (t_test.Manager.PartDestruible is Motor)
                {
                    t_test.Manager.PartDestruible.Heal(capacityToRepairWithTest* ((Ship.Instance.SkillControl.LevelPlayer * 0.5f) / 2.5f));
                    t_test.OnCompleteTest();
                }
            }
        }

    }
}
