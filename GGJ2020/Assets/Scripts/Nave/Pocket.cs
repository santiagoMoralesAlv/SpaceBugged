using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    [SerializeField]
    private GameObject tool;
    [SerializeField]
    private Transform tf;

    private void Awake()
    {
        tf = this.transform;
    }
    public bool HasTool() {
        if (tool != null) {
            return true;
        }
        return false;
    }

    public GameObject SaveTool(GameObject t_tool) {
        GameObject resultTool = null;

        if (HasTool()) {
            resultTool = TakeOutTool();
        }

        t_tool.SetActive(false);
        t_tool.transform.SetParent(tf);
        tool = t_tool;

        return resultTool;
    }

    public GameObject TakeOutTool() {
        GameObject toolToBringOut = tool;
        toolToBringOut.SetActive(true);
        tool = null;

        return toolToBringOut;
    }
}
