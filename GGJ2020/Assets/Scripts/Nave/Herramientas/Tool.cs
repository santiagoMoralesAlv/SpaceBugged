using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum toolType
{
    Termofanton,
    BaseTermoFanton,
    Cautin,
    Holograma,
    Laser,
    Martillo,
    Mascara,
    TarroDeAgua
}

public abstract class Tool : MonoBehaviour
{
    [SerializeField]
    private toolType type;

    public delegate void UpdateState (bool state);
    public UpdateState e_OnGrab;
    
    private bool isGrabbed;


    public bool IsGrabbed { get => isGrabbed;}
    public toolType Type { get => type;}

    public void TakeTool() {
        isGrabbed = true;
        NotifyGrab();
    }

    public void DropTool() {
        isGrabbed = false;
        NotifyGrab();
    }

    private void NotifyGrab() {
        try
        {
            e_OnGrab(isGrabbed);
        }
        catch {
        }
    }    

}
