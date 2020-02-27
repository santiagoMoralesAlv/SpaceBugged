using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_Tools : Tutorial
{
    [SerializeField]
    private ActiveButton gravityButton;

    [SerializeField]
    private ActiveTool activeTool;
    [SerializeField]
    private ActiveTool pasiveTool;

    private bool activeToolComplete, pasiveToolComplete, gravityButtonComplete;

    private void Awake()
    {
        gravityButton.e_UpdateState += CheckButtonGravity;
        activeTool.e_InUse += CheckActiveTool;
        pasiveTool.e_OnGrab += CheckGrabTool;
    }

    private void Update()
    {
        CheckStatus();
    }

    override protected bool CheckIsComplete()
    {
        return (activeToolComplete && pasiveToolComplete && gravityButtonComplete);
    }

    public void CheckButtonGravity(bool value)
    {
        if (value)
        {
            if (e_completeStep != null)
            {
                e_completeStep();
            }
            gravityButtonComplete = true;
        }
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
}
