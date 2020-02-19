using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public delegate void UpdateState (bool state);
    public UpdateState OnGrab;

    [SerializeField]
    private bool isGrabbed;
    [SerializeField]
    private Rigidbody rb;


    public bool IsGrabbed { get => isGrabbed;}

    public void TakeTool() {
        isGrabbed = true;
        Notify();
    }

    public void DropTool() {
        isGrabbed = false;
        Notify();
    }

    private void Notify() {
        try
        {
            OnGrab(isGrabbed);
        }
        catch {
        }
    }    

}
