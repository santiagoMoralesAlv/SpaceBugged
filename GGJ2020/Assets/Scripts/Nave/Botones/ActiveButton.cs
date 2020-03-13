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
    private VRTK_ArtificialSlider vrtkSlider;

    virtual protected void Awake()
    {
        vrtkSlider.ValueChanged += CheckActivation;
    }

    protected void CheckActivation(object sender, ControllableEventArgs e) {
        if (vrtkSlider.GetStepValue(vrtkSlider.GetValue()) >= 1) Activation();
    }

    abstract protected void Activation();

}
