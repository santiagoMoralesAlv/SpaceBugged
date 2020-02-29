using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToolSFX : MonoBehaviour
{
    [SerializeField]
    protected ActiveTool tool;

    protected void Awake()
    {
        if (tool == null)
        {
            tool = this.GetComponent<ActiveTool>();
        }

        tool.e_InUse += UpdateSFX;
    }

    protected abstract void UpdateSFX(bool value);
}
