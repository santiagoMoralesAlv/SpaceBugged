using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;

public class Test : MonoBehaviour
{
    public delegate void Complete(GameObject obj);
    public Complete e_Complete;

    private ManagerTest manager;

    public ManagerTest Manager { get => manager; set => manager=value; }

    public bool isShowing;
    [SerializeField]
    private GameObject Sprite;

    virtual protected void Awake()
    {
        ConstraintSource headsetConstraint = new ConstraintSource();
        headsetConstraint.sourceTransform = VRReferences.Instance.HeadsetTf;
        headsetConstraint.weight = 1;
        this.GetComponent<LookAtConstraint>().AddSource(headsetConstraint);
    }

    public void OnCompleteTest()
    {
        if (e_Complete != null)
        {
            e_Complete(this.gameObject);
        }
    }

    public void Show(bool value) {
        isShowing = value;
        Sprite.SetActive(value);
    }

}
