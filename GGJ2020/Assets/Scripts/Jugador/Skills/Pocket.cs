using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Pocket : MonoBehaviour
{
    [SerializeField]
    private GameObject toolIn, toolGrabbed;
    [SerializeField]
    private Transform tf;

    private bool inGrab;

    [SerializeField]
    private VRTK_InteractGrab vrtkGrab;

    private void Awake()
    {
        tf = this.transform;

        vrtkGrab.ControllerGrabInteractableObject += GrabTool;
        vrtkGrab.ControllerUngrabInteractableObject += ReleaseTool;
    }

    private void GrabTool(object sender, ObjectInteractEventArgs t_grab)
    {
        if (t_grab.target.gameObject.CompareTag("Herramienta"))
        {
            toolGrabbed = t_grab.target;
            inGrab = true;
        }
    }

    private void ReleaseTool(object sender, ObjectInteractEventArgs t_grab)
    {
        if (t_grab.target.gameObject == toolGrabbed)
        {
            toolGrabbed =null;
            inGrab = false;
        }
    }

    public void InteractionWithPocket()
    {
        if (HasToolIn())
        {
            TakeOutTool();
        }else
        {
            if (inGrab)
            {
                SaveTool();
            }
        }

    }

    public bool HasToolIn() {
        if (toolIn != null) {
            return true;
        }
        return false;
    }

    private void SaveTool() {
        if (toolGrabbed != null) {
            toolIn = toolGrabbed;
            toolIn.SetActive(false);
            toolIn.transform.SetParent(tf);
            toolIn.transform.localPosition = Vector3.zero;
        }
    }

    private void TakeOutTool() {
        GameObject toolToBringOut = toolIn;
        toolIn = null;

        toolToBringOut.SetActive(true);
        toolToBringOut.transform.SetParent(Ship.Instance.GoHerramientas);
    }

    private void UpdateSprite()
    {

    }
}
