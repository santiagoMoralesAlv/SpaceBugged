using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : ActiveTool
{
    override protected void Use()
    {
        Notify();
    }
}
