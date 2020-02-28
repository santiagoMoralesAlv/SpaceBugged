using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class tut_SpecificTool : Tutorial
{
    [SerializeField]
    private bool isPartRepaired;

    [SerializeField]
    private DestroyablePart part;

    private void Awake()
    {
        Ship.Instance.e_UpdateParts += CheckStatus;
    }

    override protected bool CheckIsComplete()
    {
        CheckRepair();
        return (isPartRepaired);
    }

    public void CheckRepair()
    {

        switch (part)
        {
            case DestroyablePart.Motor:
                if (Ship.Instance.MotorHealth == 1)
                    isPartRepaired = true;
                break;
            case DestroyablePart.FuenteEnergia:
                if (Ship.Instance.Gas == 1)
                    isPartRepaired = true;
                break;
            case DestroyablePart.Cable1:
                if (Ship.Instance.CablesHealth[0] == 1)
                    isPartRepaired = true;
                break;
            case DestroyablePart.Cable2:
                if (Ship.Instance.CablesHealth[1] == 1)
                    isPartRepaired = true;
                break;
            case DestroyablePart.Cable3:
                if (Ship.Instance.CablesHealth[2] == 1)
                    isPartRepaired = true;
                break;
            case DestroyablePart.Vidrio:
                if (Ship.Instance.GlassClarity == 1)
                    isPartRepaired = true;
                break;
        }
    }
}
