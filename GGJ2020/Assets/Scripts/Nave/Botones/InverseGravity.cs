using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InverseGravity : MonoBehaviour
{
    public UnityAction e_Execute;

    [SerializeField]
    private GameObject[] tools;
    [SerializeField]
    private float gravityForce;

    [SerializeField]
    private float distance;


    public void Use()
    {
        if (Ship.Instance.SkillControl.CanLaunchGravity) {
            SetForce();
        }
    }

    public void SetForce()
    {
        bool result = false;
        foreach (GameObject tool in tools)
        {
            if (tool.activeInHierarchy)
            {
                if (Vector3.Distance(this.transform.position, tool.transform.position) > distance)
                {
                    tool.GetComponent<Rigidbody>().AddForce((-tool.transform.position + this.transform.position).normalized * gravityForce, ForceMode.Impulse);
                    result = true;
                }
            }
        }

        if (result && e_Execute != null) {
            e_Execute();
        }
    }
}
