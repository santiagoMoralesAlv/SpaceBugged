using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BugHand : MonoBehaviour
{

    private Tool tool;
    private bool inGrab;
    private Transform tf;

    [SerializeField]
    private VRTK_InteractGrab vrtkGrab;
    [SerializeField]
    private VRTK_InteractUse vrtkUse;
    [SerializeField]
    private VRTK_Pointer vrtkPointer;
    [SerializeField]
    private VRTK_InteractNearTouch vrtkNearTouch;


    private void Awake()
    {
        tf = this.transform;

        vrtkGrab.ControllerGrabInteractableObject += GrabTool;
        vrtkGrab.ControllerUngrabInteractableObject += ReleaseTool;

        vrtkUse.ControllerUseInteractableObject += UseTool;
        vrtkUse.ControllerUnuseInteractableObject += UnUseTool;

        vrtkUse.ControllerUseInteractableObject += UseTool;
        vrtkUse.ControllerUnuseInteractableObject += UnUseTool;

        vrtkNearTouch.ControllerNearTouchInteractableObject += NearTouch;
        vrtkNearTouch.ControllerNearUntouchInteractableObject += NearUnTouch;
        /*
         Pendiente el uso del pointer para el hub 
         
        vrtkPointer. += UseTool;
        vrtkPointer. += UnUseTool;*/
    }

    private void GrabTool(object sender, ObjectInteractEventArgs t_grab)
    {
        if (t_grab.target.gameObject.CompareTag("Herramienta"))
        {
            tool = t_grab.target.GetComponent<Tool>();
            tool.TakeTool();
            inGrab = true;
        }
    }
    private void ReleaseTool(object sender, ObjectInteractEventArgs t_grab)
    {
        if (t_grab.target.gameObject.CompareTag("Herramienta"))
        {
            tool.DropTool();
            inGrab = false;
        }
    }

    private void UseTool(object sender, ObjectInteractEventArgs t_Use)
    {
        if(t_Use.target.GetComponent<Tool>() != null && t_Use.target.GetComponent<Tool>() == tool)
        {
            if (tool != null)
            {
                if (tool is ActiveTool)
                {
                    (tool as ActiveTool).Use();
                }
            }
        }
    }
    private void UnUseTool(object sender, ObjectInteractEventArgs t_Use)
    {
        if (tool != null)
        {
            if (tool is ActiveTool)
            {
                (tool as ActiveTool).UnUse();
            }
        }
    }

    private void NearTouch(object sender, ObjectInteractEventArgs t_Use)
    {
        if (t_Use.target.CompareTag("Test"))
        {
            t_Use.target.GetComponent<Test>().Show(true);
        }
    }
    private void NearUnTouch(object sender, ObjectInteractEventArgs t_Use)
    {
        if (t_Use.target.CompareTag("Test"))
        {
            t_Use.target.GetComponent<Test>().Show(false);
        }
    }

}
