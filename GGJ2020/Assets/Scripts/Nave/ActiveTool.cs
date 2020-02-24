using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveTool : Tool
{
    

    public Tool.UpdateState e_UpdateState;

    protected bool inUse;

    virtual public void Use()
    {
        inUse = true;
        Notify();
    }

    virtual public void UnUse()
    {
        inUse = false;
        Notify();
    }

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
