using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tut_SpecificTool : Tutorial
{
    [SerializeField]
    private bool isPartRepaired;

    [SerializeField]
    private DestroyablePart part;
    
    [SerializeField]
    private Image imgPart;

    private void Awake()
    {
        Ship.Instance.e_UpdateParts += CheckStatus;
    }

    override protected bool CheckIsComplete()
    {
        CheckRepair();
        UpdateGUI();
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

    override protected void UpdateGUI()
    {
        switch (part)
        {
            case DestroyablePart.Motor:
                imgPart.rectTransform.localScale = new Vector3(Ship.Instance.MotorHealth / 1, 1f, 1f);
                break;
            case DestroyablePart.FuenteEnergia:
                imgPart.rectTransform.localScale = new Vector3(Ship.Instance.Gas / 1, 1f, 1f);
                break;
            case DestroyablePart.Cable1:
                imgPart.rectTransform.localScale = new Vector3(Ship.Instance.CablesHealth[0] / 1, 1f, 1f);
                break;
            case DestroyablePart.Cable2:
                imgPart.rectTransform.localScale = new Vector3(Ship.Instance.CablesHealth[1] / 1, 1f, 1f);
                break;
            case DestroyablePart.Cable3:
                imgPart.rectTransform.localScale = new Vector3(Ship.Instance.CablesHealth[2] / 1, 1f, 1f);
                break;
            case DestroyablePart.Vidrio:
                imgPart.rectTransform.localScale = new Vector3(Ship.Instance.GlassClarity / 1, 1f, 1f);
                break;
        }
    }
}
