using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cautin : ActiveTool
{
    private int numCableToRepair;
    [SerializeField]
    private float capacityToRepair;

    override protected void Use() {
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
            Ship.Instance.ApplyCableHeal(numCableToRepair, capacityToRepair * Time.deltaTime);
        }
    }
}
