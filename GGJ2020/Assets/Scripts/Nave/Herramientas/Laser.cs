using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : ActiveTool
{
    override protected void Use()
    {
        Notify();
    }
}
