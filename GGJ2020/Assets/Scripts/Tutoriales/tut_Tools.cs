using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tut_Tools : Tutorial
{
    [SerializeField]
    private ActiveTool activeTool;
    [SerializeField]
    private Tool pasiveTool;

    private bool activeToolComplete, pasiveToolComplete;


    [SerializeField]
    private Image imgPasiveComplete, imgActiveComplete;

    private void Awake()
    {
        activeTool.e_InUse += CheckActiveTool;
        pasiveTool.e_OnGrab += CheckGrabTool;
    }

    private void Update()
    {
        CheckStatus();
    }

    override protected bool CheckIsComplete()
    {
        return (activeToolComplete && pasiveToolComplete);
    }

    public void CheckGrabTool(bool value)
    {
        if (value)
        {
            if (e_completeStep != null)
            {
                e_completeStep();
            }
            pasiveToolComplete = true;
        }
    }

    public void CheckActiveTool(bool value)
    {
        if (value)
        {
            if (e_completeStep != null)
            {
                e_completeStep();
            }
            activeToolComplete = true;
        }
    }

    override protected void UpdateGUI()
    {
        imgPasiveComplete.enabled = pasiveToolComplete;
        imgActiveComplete.enabled = activeToolComplete;
    }
}
