using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;

public abstract class Handle : MonoBehaviour
{
    public Tool.UpdateState e_UpdateState;
    

    [SerializeField]
    private VRTK_ArtificialSlider vrtkSlider;

    [SerializeField]
    protected bool isTutorial;

    virtual protected void Awake()
    {
        vrtkSlider.ValueChanged += CheckActivation;
    }

    protected void CheckActivation(object sender, ControllableEventArgs e)
    {
        if (vrtkSlider.GetStepValue(vrtkSlider.GetValue()) >= 1)
        {
            Activation();
        }
    }

    abstract protected void Activation();
}
