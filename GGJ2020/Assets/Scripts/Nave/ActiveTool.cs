using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveTool : Tool
{
    

    public Tool.UpdateState e_UpdateState;

    protected bool inUse;

    public abstract void Use();
    public abstract void UnUse();

    protected void Notify()
    {

        try
        {
            e_UpdateState(inUse);
        }
        catch
        {
        }
    }
}
