using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManagerTest : MonoBehaviour
{
    [SerializeField]
    protected GameObject pf_Test;

    public abstract void GenerateNewTest();
}
