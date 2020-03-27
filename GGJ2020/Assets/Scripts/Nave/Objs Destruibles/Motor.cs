using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : PartDestruible
{
    override public void Heal(float value)
    {
        Ship.Instance.ApplyMotorHeal(value);
    }

    override public float GetHeal()
    {
        return Ship.Instance.MotorHealth;
    }
}
