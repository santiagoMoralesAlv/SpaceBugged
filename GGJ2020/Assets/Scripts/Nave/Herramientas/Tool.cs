using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public delegate void UpdateState (bool state);
    public UpdateState e_OnGrab;
    
    private bool isGrabbed;


    public bool IsGrabbed { get => isGrabbed;}

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
