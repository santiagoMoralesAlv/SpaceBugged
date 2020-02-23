using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BugHand : MonoBehaviour
{

    [SerializeField]
    private Tool tool;
    [SerializeField]
    private bool inGrab;
    private Transform tf;

    [SerializeField]
    private VRTK_InteractGrab vrtkGrab;
    [SerializeField]
    private VRTK_InteractUse vrtkUse;
    [SerializeField]
    private VRTK_Pointer vrtkPointer;
    

    private void Awake()
    {
        tf = this.transform;

        vrtkGrab.ControllerGrabInteractableObject += GrabTool;
        vrtkGrab.ControllerUngrabInteractableObject += ReleaseTool;
        
        vrtkUse.ControllerUseInteractableObject += UseTool;
        vrtkUse.ControllerUnuseInteractableObject += UnUseTool;

        
        /*
         Pendiente el uso del pointer para el hub 
         
        vrtkPointer. += UseTool;
        vrtkPointer. += UnUseTool;*/
    }

    private void GrabTool(object sender, ObjectInteractEventArgs t_grab) {
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
        if (tool != null)
        {
            if(tool is ActiveTool)
            {

                (tool as ActiveTool).Use();
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




    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Bolsillo"))
        {
            //mOSTRAR HERRAMINETA EN EL BOLSILLO
        }
    }

    private void OnTriggerStay(Collider collider)
    { 
        //OUTDATE
        /*
        if (collider.CompareTag("Herramienta")) {
            if (Input.GetKeyDown(KeyCode.E) && !inGrab) {
                if (!collider.gameObject.GetComponent<Tool>().IsGrabbed)
                {
                    GrabTool(collider.gameObject);
                }
            }
        }*/

        /*
        if (collider.CompareTag("Bolsillo")) {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (collider.GetComponent<Pocket>().HasTool()) {
                    GrabTool(collider.GetComponent<Pocket>().TakeOutTool());
                }
            }

            if (Input.GetKeyUp(KeyCode.F) && Input.GetKey(KeyCode.W))
            {
                //se guarda por si existe otra herramienta almacenada
                ReleaseTool();
                GameObject t_tool = collider.GetComponent<Pocket>().SaveTool(tool);
                tool = null;
                if (t_tool != null) //por si efectivamente devuelve una herramienta
                {
                    GrabTool(t_tool);
                }
            }
        }
        */
    }



}
