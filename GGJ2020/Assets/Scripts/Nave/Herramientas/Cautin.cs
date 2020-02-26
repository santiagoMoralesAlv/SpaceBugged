using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cautin : ActiveTool
{
    [SerializeField]
    private float capacityToRepair, capacityToRepairWithTest;
    

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Cables"))
        {
            if (inUse)
            {
                collider.gameObject.GetComponent<Cable>().Heal(capacityToRepair* ((Ship.Instance.SkillControl.LevelPlayer * 0.5f) / 2.5f));
            }
        }

        if (collider.gameObject.CompareTag("Test"))
        {
            if (inUse)
            {
                Test t_test = collider.gameObject.GetComponent<Test>();
                if (t_test.Manager.PartDestruible is Cable)
                {
                    t_test.Manager.PartDestruible.Heal(capacityToRepairWithTest* ((Ship.Instance.SkillControl.LevelPlayer*0.5f) / 2.5f));
                    t_test.OnCompleteTest();
                }
            }
        }

    }
}
