using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class tut_SpecificTool : Tutorial
{
    [SerializeField]
    private bool isPartRepaired;



    override protected bool CheckIsComplete()
    {
        return (false);
    }

    public void CheckTool()
    {
        isPartRepaired = true;
    }
}
