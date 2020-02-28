using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveTool : Tool
{
    public Tool.UpdateState e_InUse;

    protected bool inUse;

    virtual public void Use()
    {
        inUse = true;
        NotifyUse();
    }

    virtual public void UnUse()
    {
        inUse = false;
        NotifyUse();
    }

    protected void NotifyUse()
    {

        try
        {
            e_InUse(inUse);
        }
        catch
        {
        }
    }
}
