using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class Pocket : MonoBehaviour
{
    [SerializeField]
    private Sprite sprPocket, sprTermofanton, sprBaseTermoFanton, sprCautin, sprHolograma, sprLaser, sprMartillo, sprMascara, sprTarroDeAgua;

    [SerializeField]
    private Image imgPocket;

    [SerializeField]
    private GameObject toolIn, toolGrabbed;
    [SerializeField]
    private Transform tf;

    [SerializeField]
    private bool inGrab;

    [SerializeField]
    private VRTK_InteractGrab vrtkGrab;

    private void Awake()
    {
        tf = this.transform;
        this.gameObject.SetActive(false);

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

            UpdateSprite();
        }
    }

    private void TakeOutTool() {
        GameObject toolToBringOut = toolIn;
        toolIn = null;

        toolToBringOut.SetActive(true);
        toolToBringOut.transform.SetParent(Ship.Instance.GoHerramientas);


        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if(toolIn != null) { 
        toolType tType = toolIn.GetComponent<Tool>().Type;

        switch (tType)
        {
            case toolType.Termofanton:
                imgPocket.sprite = sprTermofanton;
                break;
            case toolType.BaseTermoFanton:
                break;
            case toolType.Cautin:
                imgPocket.sprite = sprCautin;
                break;
            case toolType.Holograma:
                imgPocket.sprite = sprHolograma;
                break;
            case toolType.Laser:
                imgPocket.sprite = sprLaser;
                break;
            case toolType.Martillo:
                imgPocket.sprite = sprMartillo;
                break;
            case toolType.Mascara:
                imgPocket.sprite = sprMascara;
                break;
            case toolType.TarroDeAgua:
                imgPocket.sprite = sprTarroDeAgua;
                break;
        }
        }else
        {
            imgPocket.sprite = sprPocket;
        }
    }
}
