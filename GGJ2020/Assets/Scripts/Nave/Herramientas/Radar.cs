using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : ActiveTool
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
