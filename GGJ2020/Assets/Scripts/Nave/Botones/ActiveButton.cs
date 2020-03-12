using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;

public abstract class ActiveButton : MonoBehaviour
{
    public Tool.UpdateState e_UpdateState;

    protected bool inUse;

    [SerializeField]
    private VRTK_ArtificialRotator vrtkRotator;

    private void Awake()
    {
        vrtkRotator.ValueChanged += CheckActivation;
    }

    protected void CheckActivation(object sender, ControllableEventArgs e) {
        if (vrtkRotator.GetValue() == 1) Activation();
    }

    abstract protected void Activation();

}
