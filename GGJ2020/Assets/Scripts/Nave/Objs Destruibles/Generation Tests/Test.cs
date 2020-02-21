using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;

public class Test : MonoBehaviour
{
    public UnityAction e_Complete;

    private ManagerTest manager;

    public ManagerTest Manager { get => manager; set => manager=value; }

    virtual protected void Awake()
    {
        ConstraintSource headsetConstraint = new ConstraintSource();
        headsetConstraint.sourceTransform = HeadsetReference.Instance.HeadsetTf;
        headsetConstraint.weight = 1;
        this.GetComponent<LookAtConstraint>().AddSource(headsetConstraint);
    }

    public void OnCompleteTest()
    {
        if (e_Complete != null)
        {
            e_Complete();
        }
    }

}
