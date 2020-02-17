using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugHand : MonoBehaviour
{

    [SerializeField]
    private GameObject tool;
    [SerializeField]
    private bool inGrab;
    private Transform tf;

    private void Awake()
    {
        tf = this.transform;
    }

    private void GrabTool(GameObject t_tool) {

        t_tool.transform.SetParent(tf);
        t_tool.transform.localPosition = Vector3.zero;
        t_tool.transform.localRotation = Quaternion.identity;
        t_tool.GetComponent<Tool>().TakeTool();
        tool = t_tool;
        //Queda pendiente la orientacion de las herramientas al agarrarse
        inGrab = true;
    }

    private void ReleaseTool()
    {
        tool.transform.SetParent(Ship.Instance.GoHerramientas.transform);

        tool.GetComponent<Tool>().DropTool();
        inGrab = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && inGrab)
        {
            ReleaseTool();
            tool = null;
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
        if (collider.CompareTag("Herramienta")) {
            if (Input.GetKeyDown(KeyCode.E) && !inGrab) {
                if (!collider.gameObject.GetComponent<Tool>().IsGrabbed)
                {
                    GrabTool(collider.gameObject);
                }
            }
        }


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
    }



}
