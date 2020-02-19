using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holograma : ActiveTool
{
    override public void Use()
    {
        Notify();
    }

    override public void UnUse()
    {
        Notify();
    }
}
