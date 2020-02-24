using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManagerTest : MonoBehaviour
{
    [SerializeField]
    protected GameObject pf_Test;
    protected Test test;

    public abstract void GenerateNewTest();


    private PartDestruible partDestruible;

    public PartDestruible PartDestruible { get => partDestruible; }

    virtual protected void Awake()
    {
        partDestruible = this.GetComponent<PartDestruible>();
    }
}
