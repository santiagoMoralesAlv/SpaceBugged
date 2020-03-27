using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolLineRenderer : ToolSFX
{
    [SerializeField]
    private LineRenderer line;

    new private void Awake()
    {
        base.Awake();
        if (line == null)
        {
            line = this.GetComponent<LineRenderer>();
        }
        
        tool.e_InUse += UpdateSFX;
    }

    override protected void UpdateSFX(bool value)
    {
        if (value)
        {
            line.enabled = true;
            line.SetPosition(0, (tool as TermoFanton).Aim.position);
            line.SetPosition(1, (tool as TermoFanton).PointHit);
        }
        else
        {
            line.enabled = false;
        }
    }
}
