using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTool_EnabledGO : ToolSFX
{
    [SerializeField]
    private GameObject go;

    new private void Awake()
    {
        base.Awake();
        if (go == null)
        {
            go = this.gameObject;
        }
    }

    override protected void UpdateSFX(bool value)
    {
        go.SetActive(value);
    }
}
