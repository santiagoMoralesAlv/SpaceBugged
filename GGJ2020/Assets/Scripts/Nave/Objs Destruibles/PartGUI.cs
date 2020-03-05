using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartGUI : MonoBehaviour
{

    [SerializeField]
    private Image imgPart;

    [SerializeField]
    private DestroyablePart part;

    private void Update()
    {
        UpdatePartStats();
    }

    private void UpdatePartStats()
    {
        switch (part)
        {
            case DestroyablePart.Motor:
                imgPart.rectTransform.localScale = new Vector3((Ship.Instance.MotorHealth), 1f, 1f);
                break;
            case DestroyablePart.FuenteEnergia:
                imgPart.rectTransform.localScale = new Vector3((Ship.Instance.Gas), 1f, 1f);
                break;
            case DestroyablePart.Cable1:
                imgPart.rectTransform.localScale = new Vector3((Ship.Instance.CablesHealth[0]), 1f, 1f);
                break;
            case DestroyablePart.Cable2:
                imgPart.rectTransform.localScale = new Vector3((Ship.Instance.CablesHealth[1]), 1f, 1f);
                break;
            case DestroyablePart.Cable3:
                imgPart.rectTransform.localScale = new Vector3((Ship.Instance.CablesHealth[2]), 1f, 1f);
                break;
            case DestroyablePart.Vidrio:
                imgPart.rectTransform.localScale = new Vector3((Ship.Instance.GlassClarity), 1f, 1f);
                break;
        }
    }
}
