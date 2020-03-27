using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuenteEnergia : PartDestruible
{    
    override public void Heal(float value)
    {
        Ship.Instance.ApplyGasHeal(value);
    }

    override public float GetHeal()
    {
        return Ship.Instance.Gas;
    }
}
