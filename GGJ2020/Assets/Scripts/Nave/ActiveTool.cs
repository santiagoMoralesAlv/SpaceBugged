using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveTool : Tool
{
    

    public Tool.UpdateState e_Use;

    private bool inUse;

    protected abstract void Use();

    protected void Notify()
    {
        try
        {
            e_Use(inUse);
        }
        catch
        {
        }
    }
}
