using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : PartDestruible
{
    [SerializeField]
    private int numCable;

    public int NumCable { get => numCable; }

    override public void Heal(float value)
    {
        Ship.Instance.ApplyCableHeal(numCable, value * Time.deltaTime);
    }

    override public float GetHeal()
    {
        return Ship.Instance.CablesHealth[numCable];
    }
}
